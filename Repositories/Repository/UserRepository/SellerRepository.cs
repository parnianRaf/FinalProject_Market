using System;
using System.Collections.Generic;
using System.Linq;
using AppCore;
using AppCore.DtoModels;
using AppCore.DtoModels.Admin;
using AppCore.DtoModels.Customer;
using AppCore.DtoModels.Seller;
using AppCore.Enum;
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
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly MarketContext _context;
        #endregion

        #region ctor
        public SellerRepository(UserManager<User> userManager
            , SignInManager<User> signInManager
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
            var user = _mapper.Map<User>(sellerDto);
            var addResult = await _userManager.CreateAsync(user, sellerDto.Password);
            var resultRoleAdd = _userManager.AddToRoleAsync(user, "seller");
            if (resultRoleAdd.IsCompletedSuccessfully)
            {
                return true;
            }
            AggregateException? exception = resultRoleAdd.Exception;
            return false;
        }

        public async Task<bool> LogIn(LogInSellerDto entity, CancellationToken cancellation)
        {
            bool resultLogIn = false;
            var result = await _signInManager.PasswordSignInAsync(entity.UserName, entity.Password, entity.IsRememberMe, false);
            if (result.Succeeded)
            {
                return !resultLogIn;
            }
            return resultLogIn;
        }

        public async Task LogOut(CancellationToken cancellation)
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<EditSellerDto> UpdateGetSeller(int id, CancellationToken cancellation)
        {
            var seller = await _userManager.FindByIdAsync(id.ToString());
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
            User? user = await _userManager.FindByIdAsync(sellerDto.Id.ToString());
            if (user != null)
            {
                user = _mapper.Map<User>(sellerDto);
                var editResult = await _userManager.UpdateAsync(user);
                if (editResult.Succeeded)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<bool> DeleteSeller(int id, CancellationToken cancellationToken)
        {
            bool result = false;
            User? seller = await _userManager.FindByIdAsync(id.ToString());
            if (seller != null)
            {
                seller.IsDeleted = true;
                seller.DeletedAt = DateTime.Now;
                //custoomer.DeleteBy
                await _userManager.UpdateAsync(seller);
                return !result;
            }
            return result;

        }
        
        //public async Task<EditSellerDto> GetSeller(int id, CancellationToken cancellation)
        //{
        //    User? seller = await _userManager.FindByIdAsync(id.ToString());
        //    if (seller != null)
        //    {
        //        return _mapper.Map<EditSellerDto>(seller);

        //    }
        //    return new EditSellerDto();
        //}

        public async Task<List<DetailSellerDto>> GetAllSellers(CancellationToken cancellationToken)
        {
            var result = await _userManager.GetUsersInRoleAsync("seller");
            return _mapper.Map<List<DetailSellerDto>>(result);
        }

        public async Task<bool> AchieveMedal(int sellerId, CancellationToken cancellationToken)
        {
            User? seller = await _userManager.FindByIdAsync(sellerId.ToString());
            if (seller != null)
            {
                seller.HasMedal = true;
                seller.MedalAchievedAt = DateTime.Now;
                await _userManager.UpdateAsync(seller);
                return true;
            }
            return false;

        }

        #endregion






    }
}

