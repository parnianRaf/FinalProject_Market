using AppCore;
using AppCore.DtoModels.Offer;

namespace Service
{
    public interface IOfferService
    {
        Task<List<Offer>> GetAuctionOffers(int auctionId, CancellationToken cancellationToken);
        Task<List<T>> GetAllOffers<T>(CancellationToken cancellation);
        Task AddOffer(int offerId, User customer, Auction auction,Offer offerDto, CancellationToken cancellation);
        Task<bool> IsOfferAccepted(DetailedOfferDto offerDto, Auction auction, CancellationToken cancellation);
    }
}