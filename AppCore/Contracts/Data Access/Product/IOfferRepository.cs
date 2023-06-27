using AppCore;
using AppCore.DtoModels.Offer;

namespace Repositories.Repository.ProductRepository
{
    public interface IOfferRepository
    {
        Task AddOffer(int offerId, User customer,Auction auction,Offer offerDto, CancellationToken cancellation);
        Task<EditOfferDto> EditGetOffer(int id, CancellationToken cancellation);
        Task<List<Offer>> GetAuctionOffers(int auctionId, CancellationToken cancellation);
        Task<List<T>> GetAllOffers<T>(CancellationToken cancellation);
        Task<Offer> GetAcceptedOffer(CancellationToken cancellation);
    }
}