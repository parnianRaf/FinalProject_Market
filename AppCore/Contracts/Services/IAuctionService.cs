using AppCore.DtoModels.Auction;

namespace Service
{
    public interface IAuctionService
    {
        Task<List<DetailedAuctionDto>> GetAllPaidOrUnPaidAuctions(CancellationToken cancellation);
    }
}