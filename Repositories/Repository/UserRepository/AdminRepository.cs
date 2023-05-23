using System;
using System.Collections.Generic;
using System.Linq;
using AppCore;
using AppCore.DtoModels;
using AppSqlDataBase;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Repositories.UserRepository
{
	public class AdminRepository
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
        public async Task<bool> AddAdmin(AddCustomerDto customerDto,CancellationToken cancellation)
        {
            //var user = new IdentityUser<int>()
            //{
            //    Email = customerDto.Email,
            //    PhoneNumber=customerDto.PhoneNumber,
            //     UserName=customerDto.UserName,
            //};
            var user = _mapper.Map<IdentityUser<int>>(customerDto);
            var addResult = await _userManager.CreateAsync(user, customerDto.Password);
            
            

            if(addResult.Succeeded)
            {
                _userManager.AddToRoleAsync(user, "Customer");
                context.Customers.Add(_mapper.Map<Customer>(user));
                await context.SaveChangesAsync(cancellation);
                //Logger.LogInformation("{0} added by {1}",user.UserName,user.Id);
                return true;
            }
            return false;
        }

        public async Task<EditCustomerDto> UpdateGetCustomer(int id, CancellationToken cancellation)
        {
            Customer? customer = await context.Customers.Where(c => c.Id == id).FirstOrDefaultAsync(cancellation);
            if(customer!=null)
            {
                return _mapper.Map<EditCustomerDto>(customer);

            }
            return new EditCustomerDto();
        }

        public async Task<bool> UpdateCustomer(EditCustomerDto customerDto, CancellationToken cancellation)
        {
            //var user = new IdentityUser<int>()
            //{
            //    Email = customerDto.Email,
            //    PhoneNumber = customerDto.PhoneNumber,
            //    UserName = customerDto.UserName,
            //};
            var user = _mapper.Map<IdentityUser<int>>(customerDto);
            var editResult = await _userManager.UpdateAsync(user);
            if (editResult.Succeeded)
            {
                context.Customers.Update(_mapper.Map<Customer>(customerDto));
                await context.SaveChangesAsync(cancellation);
                return true;
            }
            return false;
        }

        public async Task DeleteCustomer(int id,CancellationToken cancellationToken)
        {
            var customer =await context.Customers.Where(c => c.Id == id).FirstOrDefaultAsync(cancellationToken);
            customer.IsDeleted = true;
            customer.DeleteAt = DateTime.Now;
            //custoomer.DeleteBy
            context.Customers.Update(customer);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<DetailCustomerDto>> GetAllCustomers(CancellationToken cancellationToken)
        {
            var result = await (context.Customers.ToListAsync(cancellationToken));
            return _mapper.Map<List<DetailCustomerDto>>(result);
        }

        #endregion






    }
}

