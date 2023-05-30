using System;
using AppCore.AppServices.Admin_.Query;
using AppCore.DtoModels.Auction;
using Repositories.Repository.ProductRepository;

namespace AppService.Admin.Queries
{
    public class GetAllAuctions : IGetAllAuctions
    {
        #region field
        private readonly IAuctionRepository _auctionRepository;
        #endregion

        #region ctor
        public GetAllAuctions(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }
        #endregion

        #region Implementation
        public async Task<List<DetailedAuctionDto>> Execute(CancellationToken cancellation)
        {
            return await _auctionRepository.GetAllAuctions(cancellation);
        }
        #endregion
    }
}

