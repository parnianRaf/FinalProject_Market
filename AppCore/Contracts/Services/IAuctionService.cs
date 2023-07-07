using AppCore;
using AppCore.DtoModels.Auction;
using AppCore.DtoModels.Product;
using Repositories.Repository.ProductRepository;

namespace Service
{
    public interface IAuctionService
    {
        Task<Auction> AddAuction(int id, int sellerId, List<Product> products, Auction auction, CancellationToken cancellation);

        Task<List<DetailedAuctionDto>> GetAllPaidOrUnPaidAuctions(CancellationToken cancellation);

        Task<Auction> GetAuction(int id, CancellationToken cancellation);

        Task<List<DetailedAuctionDto>> GetAllCustomerAuctions(int customerId, CancellationToken cancellation);

        Task<List<DetailedAuctionDto>> GetAllSuccededSellerAuctions(int sellerId, CancellationToken cancellation);

        Task<List<Auction>> GetAllEntityAuction(CancellationToken cancellation);

        Task UpdateAuction(Auction auction, CancellationToken cancellation);

        Task<List<DetailedAuctionDto>> GetAllAuctions(CancellationToken cancellation);

        Task<List<DetailedAuctionDto>> GetAllAvailableAuctions(CancellationToken cancellation);

        Task<DetailedAuctionDto> GetDetailedAuction(int id, CancellationToken cancellation);

        Task<bool> AcceptComment(int auctionId, CancellationToken cancellation);

        Task<bool> RejectComment(int auctionId, CancellationToken cancellation);
    }
}