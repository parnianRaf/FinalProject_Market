using System;
using AppCore.AppServices.Admin.Query;
using AppCore.DtoModels.Customer;
using AppCore.DtoModels.Seller;
using Repositories.UserRepository;

namespace AppService.Admin.Queries
{
    public class GetSeller : IGetSeller
    {
        #region field
        private readonly ISellerRepository _sellerRepository;
        #endregion

        #region ctor
        public GetSeller(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }
        #endregion

        #region Implementation
        public async Task<FullDetailSellerDto> Execute(int id, CancellationToken cancellation)
        {
            return await _sellerRepository.GetSellerProfile(id, cancellation);
        }
        #endregion
    }
}

