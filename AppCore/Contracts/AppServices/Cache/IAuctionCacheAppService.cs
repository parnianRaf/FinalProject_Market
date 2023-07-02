using AppCore;

namespace Service
{
    public interface IAuctionCacheAppService
    {
        Task SetCache(CancellationToken cancellation);
        Task<List<Auction>> GetCache(CancellationToken cancellation);
    }
}