using AppCore;
using AppCore.DtoModels.Auction;
using AppCore.DtoModels.Offer;
using Repositories.Repository.ProductRepository;

namespace AppService.Admin_
{
    public interface IAuctionAppService
    {
        Task AddOffer(DetailedOfferDto offerDto, CancellationToken cancellation);
        Task<Auction> AddAuction(AddAuctionDto auctionDto, CancellationToken cancellation);
        Task UpdateAuction(Auction auction, CancellationToken cancellation);
        Task UpdateAuctions(Auction auctions, CancellationToken cancellation);
        Task<List<Auction>> GetAllEntityAuction(CancellationToken cancellation);
        Task<List<DetailedAuctionDto>> GetAllAuctions(CancellationToken cancellation);
        Task<List<DetailedAuctionDto>> GetAllAvailableDetailedAuction(CancellationToken cancellation);
        Task<DetailedAuctionDto> GetAuction(int id, CancellationToken cancellation);
        Task<bool> AcceptComment(int auctionId, CancellationToken cancellation);
        Task<bool> RejectComment(int auctionId, CancellationToken cancellation);
        Task AuctionOperation(int auctionId, CancellationToken cancellation,Double medalDiscount);
        Task<List<DateTime>> GetStartDateTimes(CancellationToken cancellation);

    }
}