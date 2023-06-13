using AppCore;
using AppCore.DtoModels.Auction;
using AppCore.DtoModels.Offer;

namespace Repositories.Repository.ProductRepository
{
    public interface IAuctionRepository
    {
        Task<bool> AcceptComment(int auctionId, CancellationToken cancellation);
        Task AddAuction(int id, int sellerId, Auction auction, CancellationToken cancellation);
        Task<bool> AddCommentByCustomer(int auctionId, int customerId, string comment, CancellationToken cancellation);
        Task<bool> EditAuction(EditAuctionDto auctionDto, CancellationToken cancellation);
        Task<EditAuctionDto> EditGetAuction(int id, CancellationToken cancellation);
        Task<List<DetailedAuctionDto>> GetAllAuctions(CancellationToken cancellation);
        Task<DetailedAuctionDto> GetAuction(int id, CancellationToken cancellation);
        Task<List<DetailedAuctionDto>> GetAllCustomersAuctions(CancellationToken cancellation, int CustomerId);
        Task<List<DetailedAuctionDto>> GetAllSellerAuctions(CancellationToken cancellation, int SellerId);
        Task<List<DetailedOfferDto>> GetOffersInSpecificAuction(int sellerId, int auctionId, CancellationToken cancellation);
        Task<List<DetailedOfferDto>> GetOffersInSpecificSellerAuction(int sellerId, int auctionId, CancellationToken cancellation);
        Task<bool> RejectComment(int auctionId, CancellationToken cancellation);
        Task<decimal> CommisionPaidBySellerAuctions(int sellerId, CancellationToken cancellation);
        Task<bool> RemoveAuction(int id, CancellationToken cancellation);
    }
}