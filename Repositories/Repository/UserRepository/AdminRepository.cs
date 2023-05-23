using System;
using System.Collections.Generic;
using System.Linq;
using AppCore;
using AppCore.DtoModels;
using AppCore.DtoModels.Admin;
using AppSqlDataBase;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Repositories.UserRepository
{
    public class AdminRepository : IAdminRepository
    {

        #region prop
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly SignInManager<IdentityUser<int>> _signInManager;
        private readonly IMapper _mapper;
        private readonly MarketContext context;
        #endregion

        #region ctor
        public AdminRepository(UserManager<IdentityUser<int>> userManager
            , SignInManager<IdentityUser<int>> signInManager
            , IMapper mapper, MarketContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            this.context = context;
        }

        #endregion
        //har admin yek admin digar mitavanad add konad
        #region Implementation
        public async Task<bool> AddAdmin(AddAdminDto adminDto, CancellationToken cancellation)
        {
            //var user = new IdentityUser<int>()
            //{
            //    Email = customerDto.Email,
            //    PhoneNumber=customerDto.PhoneNumber,
            //     UserName=customerDto.UserName,
            //};
            var user = _mapper.Map<IdentityUser<int>>(adminDto);
            var addResult = await _userManager.CreateAsync(user, adminDto.Password);



            if (addResult.Succeeded)
            {
                _userManager.AddToRoleAsync(user, "Admin");
                context.Admins.Add(_mapper.Map<Admin>(user));
                await context.SaveChangesAsync(cancellation);
                //Logger.LogInformation("{0} added by {1}",user.UserName,user.Id);
                return true;
            }
            return false;
        }

        public async Task<bool> LogIn(LogInAdminDto entity, CancellationToken cancellation)
        {
            bool resultLogIn = false;
            var result = await _signInManager.PasswordSignInAsync(entity.UserName, entity.Password, false, false);
            if (result.Succeeded)
            {
                return !resultLogIn;
            }
            return resultLogIn;
        }

        public async Task LogOut(CancellationToken cancellation)
        {
            bool resultLogIn = false;
            await _signInManager.SignOutAsync();
        }


        public async Task<EditAdminDto> UpdateGetCustomer(int id, CancellationToken cancellation)
        {
            Admin? admin = await context.Admins.Where(c => c.Id == id).FirstOrDefaultAsync(cancellation);
            if (admin != null)
            {
                return _mapper.Map<EditAdminDto>(admin);

            }
            return new EditAdminDto();
        }

        public async Task<bool> UpdateCustomer(EditAdminDto adminDto, CancellationToken cancellation)
        {
            //var user = new IdentityUser<int>()
            //{
            //    Email = customerDto.Email,
            //    PhoneNumber = customerDto.PhoneNumber,
            //    UserName = customerDto.UserName,
            //};
            var user = _mapper.Map<IdentityUser<int>>(adminDto);
            var editResult = await _userManager.UpdateAsync(user);
            if (editResult.Succeeded)
            {
                context.Admins.Update(_mapper.Map<Admin>(adminDto));
                await context.SaveChangesAsync(cancellation);
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteCustomer(int id, CancellationToken cancellationToken)
        {
            bool result = false;
            Admin? admin = await context.Admins.Where(c => c.Id == id).FirstOrDefaultAsync(cancellationToken);
            if (admin != null)
            {
                admin.IsDeleted = true;
                admin.DeletedAt = DateTime.Now;
                //custoomer.DeleteBy
                context.Admins.Update(admin);
                await context.SaveChangesAsync(cancellationToken);
                return !result;
            }
            return result;

        }

        public async Task<List<DetailAdminDto>> GetAllAdmins(CancellationToken cancellationToken)
        {
            var result = await (context.Admins.ToListAsync(cancellationToken));
            return _mapper.Map<List<DetailAdminDto>>(result);
        }

        #endregion






    }
}

