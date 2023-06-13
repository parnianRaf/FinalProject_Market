using AppCore;
using AppCore.DtoModels.Offer;

namespace Repositories.Repository.ProductRepository
{
    public interface IOfferRepository
    {
        Task AddOffer(AddOfferDto offerDto, CancellationToken cancellation);
        Task<EditOfferDto> EditGetOffer(int id, CancellationToken cancellation);
        Task<List<Offer>> GetAuctionOffers(int auctionId, CancellationToken cancellation);
    }
}