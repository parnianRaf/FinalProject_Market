using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using AppCore;
using AppCore.DtoModels;
using AppCore.DtoModels.Admin;
using AppSqlDataBase;
using AutoMapper;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Repositories.UserRepository
{
    public class AdminRepository : IAdminRepository
    {

        #region field
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _rolemanager;
        private readonly IMapper _mapper;
        private readonly MarketContext context;
        #endregion

        #region ctor
        public AdminRepository(UserManager<User> userManager
            , SignInManager<User> signInManager,
            RoleManager<IdentityRole<int>> rolemanager
            , IMapper mapper, MarketContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _rolemanager = rolemanager;
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
            var user = _mapper.Map<User>(adminDto);
            var addResult = await _userManager.CreateAsync(user, adminDto.Password);
            var addRoleResult = await _userManager.AddToRoleAsync(user, "admin");
            if (addRoleResult.Succeeded)
            {
                return true;
            }
            return false;


        }

        public async Task<SignInResult> LogIn(LogInAdminDto entity, CancellationToken cancellation)
        {
            var result = await _signInManager.PasswordSignInAsync(entity.UserName, entity.Password, entity.IsRememberMe, false);
            return result;
        }

        public async Task LogOut(CancellationToken cancellation)
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<EditAdminDto> UpdateGetCustomer(int id, CancellationToken cancellation)
        {
            User? admin = await _userManager.FindByIdAsync(id.ToString());
            //User? admin_ = await _userManager.Users.Where(c => c.Id == id).FirstOrDefaultAsync(cancellation);
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
            var user = _mapper.Map<User>(adminDto);
            var editResult = await _userManager.UpdateAsync(user);
            if (editResult.Succeeded)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteCustomer(int id, CancellationToken cancellationToken)
        {
            bool result = false;
            User? admin = await _userManager.FindByIdAsync(id.ToString());
            //User? admin = await context.Users.Where(c => c.Id == id).FirstOrDefaultAsync(cancellationToken);
            if (admin != null)
            {
                admin.IsDeleted = true;
                admin.DeletedAt = DateTime.Now;
                //admin.DeletedBy=
                await _userManager.UpdateAsync(admin);
                return !result;
            }
            return result;

        }

        public async Task<List<DetailAdminDto>> GetAllAdmins(CancellationToken cancellationToken)
        {
            var result = await (_userManager.GetUsersInRoleAsync("admin"));
            return _mapper.Map<List<DetailAdminDto>>(result);
        }

        #endregion


        public async Task<bool> SeedAdminData()
        {

            #region AdminSeed

            //var adminRole = await _rolemanager.CreateAsync(new IdentityRole<int>("admin"));
            //var x = await _userManager.CreateAsync(new User() { UserName = "test", Email = "test.test@yahoo.com" }, "P@rni@n78");

            ////await _userManager.CreateAsync(new User("te"));
            //var test = await _userManager.FindByNameAsync("test");
            //if (test != null)
            //{
            //    await _userManager.AddToRoleAsync(test, "admin");
            //    return true;
            //}
            //return false;
            #endregion

            #region SeedCustomers
            var addCustomerRole = await _rolemanager.CreateAsync(new IdentityRole<int>("customer"));
            var addCustomer = await _userManager.CreateAsync(new User() { CreatedAt = DateTime.UtcNow, FirstName = "parnian", LastName = "Rafie", UserName = "pari", Email = "pari.pari@yahoo.com" }, "P@rni@n78");
            var deletedCustomer = await _userManager.CreateAsync(new User() { CreatedAt = DateTime.UtcNow, FirstName = "zarnian", LastName = "zafie", IsDeleted = true, DeletedAt = DateTime.UtcNow, DeleteComment = "ziad harf mizad", UserName = "zari", Email = "zari.pari@yahoo.com" }, "P@rni@n78");
            var acceptedCustomer = await _userManager.CreateAsync(new User() { CreatedAt = DateTime.UtcNow, IsActive = true, ActivatedAt = DateTime.UtcNow, FirstName = "xarnian", LastName = "xafie", UserName = "xari", Email = "xari.pari@yahoo.com" }, "P@rni@n78");
            if (addCustomerRole.Succeeded)
            {
                var customer = await _userManager.FindByNameAsync("pari");
                if (customer != null)
                {
                    await _userManager.AddToRoleAsync(customer, "customer");
                }
                var customer2 = await _userManager.FindByNameAsync("zari");
                if (customer2 != null)
                {
                    await _userManager.AddToRoleAsync(customer2, "customer");
                }
                var customer3 = await _userManager.FindByNameAsync("xari");
                if (customer3 != null)
                {
                    await _userManager.AddToRoleAsync(customer3, "customer");
                }
                return true;

            }
            return false;
            #endregion

        }



    }
}

