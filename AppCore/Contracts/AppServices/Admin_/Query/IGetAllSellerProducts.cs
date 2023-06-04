using AppCore.DtoModels.Product;

namespace AppService.Admin.Queries
{
    public interface IGetAllSellerProducts
    {
        Task<List<DetailedProductDto>> Execute(int sellerId, CancellationToken cancellation);
    }
}