using System;
using AppCore.DtoModels.Auction;
using Repositories.Repository.ProductRepository;

namespace AppService.Admin_
{
    public class AuctionAppService : IAuctionAppService
    {
        #region field
        private readonly IAuctionRepository _auctionRepository;
        #endregion

        #region ctor
        public AuctionAppService(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }
        #endregion

        #region Implementation
        public async Task<List<DetailedAuctionDto>> GetAllAuctions(CancellationToken cancellation)
        {
            return await _auctionRepository.GetAllAuctions(cancellation);
        }

        public async Task<DetailedAuctionDto> GetAuction(int id, CancellationToken cancellation)
        {
            return await _auctionRepository.GetAuction(id, cancellation);
        }

        public async Task<bool> AcceptComment(int auctionId, CancellationToken cancellation)
        {
            return await _auctionRepository.AcceptComment(auctionId, cancellation);
        }

        public async Task<bool> RejectComment(int auctionId, CancellationToken cancellation)
        {
            return await _auctionRepository.RejectComment(auctionId, cancellation);
        }
        #endregion

    }
}

