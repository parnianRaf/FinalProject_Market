using System;
using System.Collections.Generic;
using System.Linq;
using AppCore;
using AppCore.DtoModels;
using AppCore.DtoModels.Admin;
using AppCore.DtoModels.Customer;
using AppCore.DtoModels.Seller;
using AppSqlDataBase;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Repositories.UserRepository
{
    public class SellerRepository : ISellerRepository
    {
        #region prop
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly SignInManager<IdentityUser<int>> _signInManager;
        private readonly IMapper _mapper;
        private readonly MarketContext _context;
        #endregion

        #region ctor
        public SellerRepository(UserManager<IdentityUser<int>> userManager
            , SignInManager<IdentityUser<int>> signInManager
            , IMapper mapper, MarketContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _context = context;
        }
        #endregion

        #region Implementation
        public async Task<bool> AddSeller(AddSelllerDto sellerDto, CancellationToken cancellation)
        {
            //var user = new IdentityUser<int>()
            //{
            //    Email = customerDto.Email,
            //    PhoneNumber=customerDto.PhoneNumber,
            //     UserName=customerDto.UserName,
            //};
            var user = _mapper.Map<IdentityUser<int>>(sellerDto);
            var addResult = await _userManager.CreateAsync(user, sellerDto.Password);



            if (addResult.Succeeded)
            {
                _userManager.AddToRoleAsync(user, "Seller");
                _context.Sellers.Add(_mapper.Map<Seller>(user));
                await _context.SaveChangesAsync(cancellation);
                //Logger.LogInformation("{0} added by {1}",user.UserName,user.Id);
                return true;
            }
            return false;
        }
        public async Task<bool> LogIn(LogInSellerDto entity, CancellationToken cancellation)
        {
            bool resultLogIn = false;
            var result = await _signInManager.PasswordSignInAsync(entity.UserName, entity.Password, false, false);
            if (result.Succeeded)
            {
                return !resultLogIn;
            }
            return resultLogIn;
        }


        public async Task<EditSellerDto> UpdateGetSeller(int id, CancellationToken cancellation)
        {
            Seller? seller = await _context.Sellers.Where(c => c.Id == id).FirstOrDefaultAsync(cancellation);
            if (seller != null)
            {
                return _mapper.Map<EditSellerDto>(seller);

            }
            return new EditSellerDto();
        }

        public async Task<bool> UpdateSeller(EditSellerDto sellerDto, CancellationToken cancellation)
        {
            //var user = new IdentityUser<int>()
            //{
            //    Email = customerDto.Email,
            //    PhoneNumber = customerDto.PhoneNumber,
            //    UserName = customerDto.UserName,
            //};
            var user = _mapper.Map<IdentityUser<int>>(sellerDto);
            var editResult = await _userManager.UpdateAsync(user);
            if (editResult.Succeeded)
            {
                _context.Sellers.Update(_mapper.Map<Seller>(sellerDto));
                await _context.SaveChangesAsync(cancellation);
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteSeller(int id, CancellationToken cancellationToken)
        {
            bool result = false;
            Seller? seller = await _context.Sellers.Where(c => c.Id == id).FirstOrDefaultAsync(cancellationToken);
            if (seller != null)
            {
                seller.IsDeleted = true;
                seller.DeletedAt = DateTime.Now;
                //custoomer.DeleteBy
                _context.Sellers.Update(seller);
                await _context.SaveChangesAsync(cancellationToken);
                return !result;
            }
            return result;

        }

        public async Task<List<DetailSellerDto>> GetAllCustomers(CancellationToken cancellationToken)
        {
            var result = await (_context.Sellers.ToListAsync(cancellationToken));
            return _mapper.Map<List<DetailSellerDto>>(result);
        }

        public async Task<bool> AchieveMedal(int sellerId, CancellationToken cancellationToken)
        {
            Seller? seller = await _context.Sellers.Where(s => s.Id == sellerId).FirstOrDefaultAsync(cancellationToken);
            if (seller != null)
            {
                seller.HasMedal = true;
                seller.MedalAchievedAt = DateTime.Now;
                _context.Sellers.Update(seller);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }

        #endregion






    }
}

