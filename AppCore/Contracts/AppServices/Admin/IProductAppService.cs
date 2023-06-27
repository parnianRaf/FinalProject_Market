using AppCore;
using AppCore.DtoModels.Category;
using AppCore.DtoModels.Product;

namespace AppService.Admin_
{
    public interface IProductAppService
    {
        Task AddProduct(AddProductDto productDto, CancellationToken cancellation);
        Task AcceptProduct(int id, CancellationToken cancellation);
        Task<List<DetailedProductDto>> GetAllSellerProducts(CancellationToken cancellation);
        //Task<List<string>> GetAllProductNames(CancellationToken cancellation);
        Task<bool> EditProduct(DetailedProductDto productDto, CancellationToken cancellation);
        Task<List<DetailedProductDto>> GetAllProducts(int sellerId, CancellationToken cancellation);
        Task<List<DetailedProductDto>> GetFirstPageProducts(CancellationToken cancellation);
        Task<DetailedProductDto> GetProduct(int id, CancellationToken cancellation);
        Task<Product> GetEntityProduct(int id, CancellationToken cancellation);
        Task<bool> RemoveProduct(int id, CancellationToken cancellation);
        Task<List<CategoryDtoModel>> GetCategories(CancellationToken cancellation);
        Task<CategoryDtoModel> GetCategory(int id, CancellationToken cancellation);
        Task<List<DetailedProductDto>> GetCategoryProducts(int categoryId, CancellationToken cancellation);
    }
}