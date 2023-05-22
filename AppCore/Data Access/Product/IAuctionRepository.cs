using AppCore.DtoModels.Product;

namespace Repositories.Repository.ProductRepository
{
    public interface IAuctionRepository
    {
        Task AddAuction(AddAuctionDto auctionDto, CancellationToken cancellation);
        Task<bool> EditAuction(EditAuctionDto auctionDto, CancellationToken cancellation);
        Task<EditAuctionDto> EditGetAuction(int id, CancellationToken cancellation);
        Task<List<DetailedAuctionDto>> GetAllAuctions(CancellationToken cancellation, int SellerId);
        Task<List<DetailedOfferDto>> GetOffersInSpecificAuction(int sellerId, int auctionId, CancellationToken cancellation);
        Task<List<DetailedProductDto>> GetProductsInSpecificAuction(int sellerId, int auctionId, CancellationToken cancellation);
        Task<bool> RemoveAuction(int id, CancellationToken cancellation);
    }
}