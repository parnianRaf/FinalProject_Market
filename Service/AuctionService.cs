using System;
using AppCore;
using AppCore.DtoModels.Auction;
using AppCore.DtoModels.Product;
using Repositories.Repository.ProductRepository;

namespace Service
{
    public class AuctionService : IAuctionService
    {
        #region field
        private readonly AuctionRepository _auctionRepository;
        #endregion
        #region ctor
        public AuctionService(AuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }
        #endregion
        #region Implementation
        public async Task<List<DetailedAuctionDto>> GetAllPaidOrUnPaidAuctions(CancellationToken cancellation)
        {
            return await _auctionRepository.GetAllPaidOrUnPaidAuctions(cancellation);
        }

        #endregion

    }
}

