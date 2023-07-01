using AppCore;
using AppCore.DtoModels.Product;
using Repositories.Repository.ProductRepository;

namespace Service
{
    public interface IProductService
    {
        List<string> GetProductNames(List<DetailedProductDto> productDtos);
        Task AddProduct(int id, int sellerId, int categoryId, int? pavilionId, string dataBaseFileName, Category category, Product product, CancellationToken cancellation);
        Task<List<DetailedProductDto>> GetAllProducts(CancellationToken cancellation, int SellerId);
        Task<List<DetailedProductDto>> GetCategoryProducts(int categoryId, CancellationToken cancellation);
        Task<List<DetailedProductDto>> GetAllProducts(CancellationToken cancellation);
        Task<List<Product>> GetAllProducts(List<int> Ids, CancellationToken cancellation, int SellerId);
        Task<Product> GetEntityProduct(int id, CancellationToken cancellation);
        Task<DetailedProductDto> GetProduct(int id, CancellationToken cancellation);
        Task<bool> EditProduct(DetailedProductDto productDto, CancellationToken cancellation);
        Task<bool> RemoveProduct(int id, CancellationToken cancellation);
        Task<bool> AcceptProduct(int id, CancellationToken cancellation);

    }
}