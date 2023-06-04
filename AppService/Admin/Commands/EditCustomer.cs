using System;
using AppCore.AppServices.Admin_.Command;
using AppCore.DtoModels.Customer;
using Microsoft.AspNetCore.Identity;
using Repositories.UserRepository;

namespace AppService.Admin.Commands
{
    public class EditCustomer : IEditCustomer
    {
        #region field
        private readonly ICustomerRepository _customerRepository;
        #endregion

        #region ctor
        public EditCustomer(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        #endregion

        #region Implementation
        public async Task<bool> Execute(EditCustomerDto customerDto, CancellationToken cancellation)
        {
            return await _customerRepository.UpdateCustomer(customerDto, cancellation);
        }
        #endregion
    }
}

