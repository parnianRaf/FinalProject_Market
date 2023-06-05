using AppCore.DtoModels.Auction;

namespace AppService.Admin_
{
    public interface IAuctionAppService
    {
        Task<List<DetailedAuctionDto>> GetAllAuctions(CancellationToken cancellation);
        Task<DetailedAuctionDto> GetAuction(int id, CancellationToken cancellation);
    }
}