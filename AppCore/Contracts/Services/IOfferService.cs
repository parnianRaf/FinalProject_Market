using AppCore;
using AppCore.DtoModels.Offer;

namespace Service
{
    public interface IOfferService
    {
        Task<List<Offer>> GetAuctionOffers(int auctionId, CancellationToken cancellationToken);
        Task<List<T>> GetAllOffers<T>(CancellationToken cancellation);
        Task<bool> CheckPrice(decimal price, CancellationToken cancellation);
        Task<decimal> PriceCheck(decimal price, CancellationToken cancellation);
        Task AddOffer(int offerId, User customer, DetailedOfferDto offerDto, CancellationToken cancellation);
        Task<bool> IsOfferAccepted(DetailedOfferDto offerDto, CancellationToken cancellation);
    }
}