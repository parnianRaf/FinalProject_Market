using System;
using AppCore.DtoModels.Auction;
using Repositories.Repository.ProductRepository;

namespace AppService.Admin.Queries
{
    public class GetAuction : IGetAuction
    {
        #region field
        private readonly IAuctionRepository _auctionRepository;
        #endregion

        #region ctor
        public GetAuction(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }
        #endregion

        #region Implementation
        public async Task<DetailedAuctionDto> Execute(int auctionId, CancellationToken cancellation)
        {
            return await _auctionRepository.GetAuction(auctionId, cancellation);
        }
        #endregion
    }
}

