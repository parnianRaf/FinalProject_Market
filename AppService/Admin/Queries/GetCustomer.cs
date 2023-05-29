using System;
using AppCore.AppServices.Admin.Query;
using AppCore.DtoModels.Customer;
using Repositories.UserRepository;

namespace AppService.Admin.Queries
{
    public class GetCustomer : IGetCustomer
    {
        #region field
        private readonly ICustomerRepository _customerRepository;
        #endregion

        #region ctor
        public GetCustomer(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        #endregion

        #region Implementation
        public async Task<FullDetailCustomerDto> Execute(int id, CancellationToken cancellation)
        {
            return await _customerRepository.GetCustomerProfile(id, cancellation);
        }
        #endregion
    }
}

