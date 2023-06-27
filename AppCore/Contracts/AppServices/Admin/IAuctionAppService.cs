using AppCore;
using AppCore.DtoModels.Auction;
using Repositories.Repository.ProductRepository;

namespace AppService.Admin_
{
    public interface IAuctionAppService
    {
        Task AddAuction(AddAuctionDto auctionDto, CancellationToken cancellation);
        Task UpdateAuction(Auction auction, CancellationToken cancellation);
        Task<List<Auction>> GetAllEntityAuction();
        Task<List<DetailedAuctionDto>> GetAllAuctions(CancellationToken cancellation);
        Task<DetailedAuctionDto> GetAuction(int id, CancellationToken cancellation);
        Task<bool> AcceptComment(int auctionId, CancellationToken cancellation);
        Task<bool> RejectComment(int auctionId, CancellationToken cancellation);
        Task AuctionOperation(int auctionId, CancellationToken cancellation,Double medalDiscount);

    }
}