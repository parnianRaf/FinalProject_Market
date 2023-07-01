using System;
using AppCore;
using AppCore.DtoModels.Auction;
using AppCore.DtoModels.Product;
using Microsoft.EntityFrameworkCore;
using Repositories.Repository.ProductRepository;

namespace Service
{
    public class AuctionService : IAuctionService
    {
        #region field
        private readonly IAuctionRepository _auctionRepository;
        #endregion

        #region ctor
        public AuctionService(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }
        #endregion

        #region Implementation
        public async Task<bool> AddAuction(int id, int sellerId, List<Product> products, Auction auction, CancellationToken cancellation)
        {
            return await _auctionRepository.AddAuction(id, sellerId, products, auction, cancellation);
        }

        public async Task<Auction> GetAuction(int id, CancellationToken cancellation)
        {
            return await _auctionRepository.GetAuction(id, cancellation);
        }

        public async Task<List<DetailedAuctionDto>> GetAllPaidOrUnPaidAuctions(CancellationToken cancellation)
        {
            return await _auctionRepository.GetAllPaidOrUnPaidAuctions(cancellation);
        }

        public async Task<List<Auction>> GetAllEntityAuction(CancellationToken cancellation)
        {
            return await _auctionRepository.GetAllEntityAuction(cancellation);
        }

        public async Task UpdateAuction(Auction auction, CancellationToken cancellation)
        {
            await _auctionRepository.UpdateAuction(auction, cancellation);
        }

        public async Task<List<DetailedAuctionDto>> GetAllAuctions(CancellationToken cancellation)
        {
            return await _auctionRepository.GetAllAuctions(cancellation);
        }

        public async Task<List<DetailedAuctionDto>> GetAllAvailableAuctions(CancellationToken cancellation)
        {
            return await _auctionRepository.GetAllAvailableAuctions(cancellation);
        }

        public async Task<DetailedAuctionDto> GetDetailedAuction(int id, CancellationToken cancellation)
        {
            return await _auctionRepository.GetDetailedAuction(id, cancellation);
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

