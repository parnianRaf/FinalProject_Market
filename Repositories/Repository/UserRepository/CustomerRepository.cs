using System;
using System.Collections.Generic;
using System.Linq;
using AppCore;
using AppCore.DtoModels;
using AppCore.DtoModels.Customer;
using AppSqlDataBase;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Repositories.UserRepository
{
    public class CustomerRepository : ICustomerRepository
    {
        #region field
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly MarketContext _context;
        #endregion

        #region ctor
        public CustomerRepository(UserManager<User> userManager
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
        public async Task<IdentityResult> AddCustomer(AddCustomerDto customerDto, CancellationToken cancellation)
        {
            //var user = new IdentityUser<int>()
            //{
            //    Email = customerDto.Email,
            //    PhoneNumber=customerDto.PhoneNumber,
            //     UserName=customerDto.UserName,
            //};
            var user = _mapper.Map<User>(customerDto);
            var addResult = await _userManager.CreateAsync(user, customerDto.Password);
            var addRole = await _userManager.AddToRoleAsync(user, "Customer");
            return addRole;


        }

        public async Task<SignInResult> LogIn(LogInCustomerDto customerDto, CancellationToken cancellation)
        {
            var result = await _signInManager.PasswordSignInAsync(customerDto.UserName, customerDto.Password, customerDto.IsRememberMe, false);
            return result;
        }

        public async Task LogOut(CancellationToken cancellation)
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<EditCustomerDto> GetCustomer(int id, CancellationToken cancellation)
        {
            User? customer = await _userManager.FindByIdAsync(id.ToString());
            if (customer != null)
            {
                return _mapper.Map<EditCustomerDto>(customer);

            }
            return new EditCustomerDto();
        }

        public async Task<FullDetailCustomerDto> GetCustomerProfile(int id, CancellationToken cancellation)
        {
            User? customer = await _userManager.FindByIdAsync(id.ToString());
            if (customer != null)
            {
                return _mapper.Map<FullDetailCustomerDto>(customer);

            }
            return new FullDetailCustomerDto();
        }

        public async Task<IdentityResult> UpdateCustomer(EditCustomerDto customerDto, CancellationToken cancellation)
        {
            //var user = new IdentityUser<int>()
            //{
            //    Email = customerDto.Email,
            //    PhoneNumber = customerDto.PhoneNumber,
            //    UserName = customerDto.UserName,
            //};
            User? user =await _userManager.FindByEmailAsync(customerDto.Email);

            user = _mapper.Map<User>(customerDto);

            return await _userManager.UpdateAsync(user);


        }

        public async Task<bool> DeleteCustomer(int id, CancellationToken cancellationToken)
        {
            bool result = false;
            User? customer = await _userManager.FindByIdAsync(id.ToString());
            if (customer != null)
            {
                customer.IsDeleted = true;
                customer.DeletedAt = DateTime.Now;
                //custoomer.DeleteBy
                return !result;
            }
            return result;

        }

        public async Task<List<DetailCustomerDto>> GetAllCustomers(CancellationToken cancellationToken)
        {
            var result = await (_userManager.GetUsersInRoleAsync("customer"));
            return _mapper.Map<List<DetailCustomerDto>>(result);
        }

        #endregion






    }
}

