using AppCore;

namespace Service
{
    public interface IOfferService
    {
        Task<List<Offer>> GetAuctionOffers(int auctionId, CancellationToken cancellationToken);
    }
}