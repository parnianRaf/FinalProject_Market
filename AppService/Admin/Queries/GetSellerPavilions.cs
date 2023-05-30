using System;
using AppCore.AppServices.Admin_.Query;
using AppCore.DtoModels;
using Repositories.Repository.ProductRepository;

namespace AppService.Admin.Queries
{
    public class GetSellerPavilions : IGetSellerPavilions
    {
        #region field
        private readonly IPavilionRepository _pavilionRepository;
        #endregion

        #region ctor
        public GetSellerPavilions(IPavilionRepository pavilionRepository)
        {
            _pavilionRepository = pavilionRepository;
        }
        #endregion

        #region Implementation
        public async Task<List<PavilionDtoModel>> Execute(int sellerId, CancellationToken cancellation)
        {
            return await _pavilionRepository.GetSellerPavilions(sellerId, cancellation);
        }
        #endregion
    }
}

