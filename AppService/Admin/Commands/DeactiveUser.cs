using System;
using AppCore.AppServices.Admin_.Command;
using Repositories.UserRepository;

namespace AppService.Admin.Commands
{
    public class DeactiveUser : IDeactiveUser
    {
        #region field
        private readonly ICustomerRepository _customerRepository;
        #endregion

        #region ctor
        public DeactiveUser(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        #endregion

        #region Implementation
        public async Task<bool> Execute(int id, CancellationToken cancellation)
        {
            return await _customerRepository.DeleteCustomer(id, cancellation);
        }
        #endregion
    }
}

