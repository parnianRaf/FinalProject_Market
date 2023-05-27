//using System;
//using System.Collections.Generic;
//using System.Linq;
//using AppCore;
//using AppCore.DtoModels;
//using AppCore.DtoModels.Customer;
//using AppSqlDataBase;
//using AutoMapper;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;

//namespace Repositories.UserRepository
//{
//    public class CustomerRepository : ICustomerRepository
//    {
//        #region prop
//        private readonly UserManager<IdentityUser<int>> _userManager;
//        private readonly SignInManager<IdentityUser<int>> _signInManager;
//        private readonly IMapper _mapper;
//        private readonly MarketContext _context;
//        #endregion

//        #region ctor
//        public CustomerRepository(UserManager<IdentityUser<int>> userManager
//            , SignInManager<IdentityUser<int>> signInManager
//            , IMapper mapper, MarketContext context)
//        {
//            _userManager = userManager;
//            _signInManager = signInManager;
//            _mapper = mapper;
//            _context = context;
//        }
//        #endregion

//        #region Implementation
//        public async Task<bool> AddCustomer(AddCustomerDto customerDto, CancellationToken cancellation)
//        {
//            //var user = new IdentityUser<int>()
//            //{
//            //    Email = customerDto.Email,
//            //    PhoneNumber=customerDto.PhoneNumber,
//            //     UserName=customerDto.UserName,
//            //};
//            var user = _mapper.Map<IdentityUser<int>>(customerDto);
//            var addResult = await _userManager.CreateAsync(user, customerDto.Password);



//            if (addResult.Succeeded)
//            {
//                _userManager.AddToRoleAsync(user, "Customer");
//                _context.Customers.Add(_mapper.Map<Customer>(user));
//                await _context.SaveChangesAsync(cancellation);
//                //Logger.LogInformation("{0} added by {1}",user.UserName,user.Id);
//                return true;
//            }
//            return false;
//        }
//        public async Task<bool> LogIn(LogInCustomerDto customerDto, CancellationToken cancellation)
//        {
//            bool resultLogIn = false;
//            var result = await _signInManager.PasswordSignInAsync(customerDto.UserName, customerDto.Password, false, false);
//            if (result.Succeeded)
//            {
//                return !resultLogIn;
//            }
//            return resultLogIn;
//        }

//        public async Task LogOut(CancellationToken cancellation)
//        {
//            bool resultLogIn = false;
//            await _signInManager.SignOutAsync();
//        }

//        public async Task<EditCustomerDto> GetCustomer(int id, CancellationToken cancellation)
//        {
//            Customer? customer = await _context.Customers.Where(c => c.Id == id).FirstOrDefaultAsync(cancellation);
//            if (customer != null)
//            {
//                return _mapper.Map<EditCustomerDto>(customer);

//            }
//            return new EditCustomerDto();
//        }

//        public async Task<bool> UpdateCustomer(EditCustomerDto customerDto, CancellationToken cancellation)
//        {
//            //var user = new IdentityUser<int>()
//            //{
//            //    Email = customerDto.Email,
//            //    PhoneNumber = customerDto.PhoneNumber,
//            //    UserName = customerDto.UserName,
//            //};
//            var user = _mapper.Map<IdentityUser<int>>(customerDto);
//            var editResult = await _userManager.UpdateAsync(user);
//            if (editResult.Succeeded)
//            {
//                _context.Customers.Update(_mapper.Map<Customer>(customerDto));
//                await _context.SaveChangesAsync(cancellation);
//                return true;
//            }
//            return false;
//        }

//        public async Task<bool> DeleteCustomer(int id, CancellationToken cancellationToken)
//        {
//            bool result = false;
//            Customer? customer = await _context.Customers.Where(c => c.Id == id).FirstOrDefaultAsync(cancellationToken);
//            if (customer != null)
//            {
//                customer.IsDeleted = true;
//                customer.DeleteAt = DateTime.Now;
//                //custoomer.DeleteBy
//                _context.Customers.Update(customer);
//                await _context.SaveChangesAsync(cancellationToken);
//                return !result;
//            }
//            return result;

//        }

//        public async Task<List<DetailCustomerDto>> GetAllCustomers(CancellationToken cancellationToken)
//        {
//            var result = await (_context.Customers.ToListAsync(cancellationToken));
//            return _mapper.Map<List<DetailCustomerDto>>(result);
//        }

//        #endregion






//    }
//}

