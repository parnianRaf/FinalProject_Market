using System;
using AppCore;
using AppCore.AppServices.Admin.Query;
using AppCore.DtoModels.Customer;
using Repositories.UserRepository;

namespace AppService.Admin
{
	public class GetCustomers:IGetCustomers
	{
		#region field
		private readonly ICustomerRepository _customerRepository;
		#endregion

		#region ctor
		public GetCustomers(ICustomerRepository customerRepository)
		{
			_customerRepository = customerRepository;
		}
        #endregion

        #region Implementation
        public async Task<List<DetailCustomerDto>> Execute(CancellationToken cancellation)
		{
			return await _customerRepository.GetAllCustomers(cancellation);
		}
        #endregion

    }
}

