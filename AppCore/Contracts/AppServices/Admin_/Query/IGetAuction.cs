using AppCore.DtoModels.Auction;

namespace AppService.Admin.Queries
{
    public interface IGetAuction
    {
        Task<DetailedAuctionDto> Execute(int auctionId, CancellationToken cancellation);
    }
}