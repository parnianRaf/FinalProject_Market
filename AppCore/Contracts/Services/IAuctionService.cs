using AppCore;
using AppCore.DtoModels.Auction;
using AppCore.DtoModels.Product;

namespace Service
{
    public interface IAuctionService
    {
        Task<List<DetailedAuctionDto>> GetAllPaidOrUnPaidAuctions(CancellationToken cancellation);
        //Task<List<Product>> GetProducts(int sellerId, List<string> productNames, CancellationToken cancellation);
    }
}