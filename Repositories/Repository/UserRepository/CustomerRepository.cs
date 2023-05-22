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
	public class UserRepository
	{

        #region prop
        private UserManager<IdentityUser<int>> UserManager { get; set; }
        private SignInManager<IdentityUser<int>> SignInManager { get; set; }
        private MarketContext Context { get; set; }
        private IMapper Mapper { get; set; }
 
        #endregion
        #region ctor
        public UserRepository(UserManager<IdentityUser<int>> userManager
            ,SignInManager<IdentityUser<int>> signInManager
            ,MarketContext context
            ,IMapper mapper)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Context = context;
            Mapper = mapper;
          
        }
        #endregion

        #region Implementation
        public async Task<bool> AddCustomer(AddCustomerDto customerDto,CancellationToken cancellation)
        {
            //var user = new IdentityUser<int>()
            //{
            //    Email = customerDto.Email,
            //    PhoneNumber=customerDto.PhoneNumber,
            //     UserName=customerDto.UserName,
            //};
            var user = Mapper.Map<IdentityUser<int>>(customerDto);
            var addResult = await UserManager.CreateAsync(user, customerDto.Password);
            

            if(addResult.Succeeded)
            {
                Context.Customers.Add(Mapper.Map<Customer>(user));
                await Context.SaveChangesAsync(cancellation);
                //Logger.LogInformation("{0} added by {1}",user.UserName,user.Id);
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateCustomer(EditCustomerDto customerDto, CancellationToken cancellation)
        {
            //var user = new IdentityUser<int>()
            //{
            //    Email = customerDto.Email,
            //    PhoneNumber = customerDto.PhoneNumber,
            //    UserName = customerDto.UserName,
            //};
            var user = Mapper.Map<IdentityUser<int>>(customerDto);
            var editResult = await UserManager.UpdateAsync(user);
            if (editResult.Succeeded)
            {
                Context.Customers.Update(Mapper.Map<Customer>(customerDto));
                await Context.SaveChangesAsync(cancellation);
                return true;
            }
            return false;
        }

        public async Task DeleteCustomer(int id,CancellationToken cancellationToken)
        {
            var customer =await Context.Customers.Where(c => c.Id == id).FirstOrDefaultAsync(cancellationToken);
            customer.IsDeleted = true;
            customer.DeleteAt = DateTime.Now;
            await Context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<DetailCustomerDto>> GetAllCustomers(CancellationToken cancellationToken)
        {
            var result = await (Context.Customers.ToListAsync());
            return Mapper.Map<List<DetailCustomerDto>>(result);
        }

        public async Task<DetailCustomerDto> GetCustomersById(int id,CancellationToken cancellationToken)
        {
            var result = await (Context.Customers.Where(c => c.Id == id).FirstOrDefaultAsync(cancellationToken));
            return Mapper.Map<DetailCustomerDto>(result);
        }

        #endregion






    }
}

