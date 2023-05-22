using AppCore.DtoModels.Product;

namespace Repositories.Repository.ProductRepository
{
    public interface IOfferRepository
    {
        Task AddOffer(AddOfferDto offerDto, CancellationToken cancellation);
        Task<EditOfferDto> EditGetOffer(int id, CancellationToken cancellation);
        Task<bool> EditOffer(EditOfferDto offerDto, CancellationToken cancellation);
        Task<List<DetailedOfferDto>> GetAllOffers(CancellationToken cancellation, int customerId);
        Task<bool> RemoveAuction(int id, CancellationToken cancellation);
    }
}