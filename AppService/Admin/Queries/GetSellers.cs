using System;
using AppCore;
using AppCore.AppServices.Admin.Query;
using AppCore.DtoModels.Customer;
using AppCore.DtoModels.Seller;
using Repositories.UserRepository;

namespace AppService.Admin
{
	public class GetSellers:IGetSellers
	{
		#region field
		private readonly ISellerRepository _sellerRepository;
		#endregion

		#region ctor
		public GetSellers(ISellerRepository sellerRepository)
		{
			_sellerRepository = sellerRepository;
		}
        #endregion

        #region Implementation
        public async Task<List<DetailSellerDto>> Execute(CancellationToken cancellation)
		{
			return await _sellerRepository.GetAllSellers(cancellation);
		}

        #endregion

    }
}

