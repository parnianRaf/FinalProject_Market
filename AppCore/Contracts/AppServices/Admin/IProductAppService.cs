using AppCore.DtoModels.Category;
using AppCore.DtoModels.Product;

namespace AppService.Admin_
{
    public interface IProductAppService
    {
        Task AcceptProduct(int id, CancellationToken cancellation);
        Task<bool> EditProduct(DetailedProductDto productDto, CancellationToken cancellation);
        Task<List<DetailedProductDto>> GetAllProducts(int sellerId, CancellationToken cancellation);
        Task<DetailedProductDto> GetProduct(int id, CancellationToken cancellation);
        Task<bool> RemoveProduct(int id, CancellationToken cancellation);
        Task<List<CategoryDtoModel>> GetCategories(CancellationToken cancellation);
    }
}