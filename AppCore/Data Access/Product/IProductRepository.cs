using AppCore;
using AppCore.DtoModels;
using AppCore.DtoModels.Product;

namespace Repositories.Repository.ProductRepository
{
    public interface IProductRepository
    {
        Task AddProduct(AddProductDto productDto, CancellationToken cancellation);
        Task<EditProductDto> EditGetProduct(int id, CancellationToken cancellation);
        Task<bool> EditProduct(EditProductDto productDto, CancellationToken cancellation);
        Task<List<DetailedProductDto>> GetAllProducts(CancellationToken cancellation, int SellerId);
        Task<List<DetailedProductDto>> GetAllProductsInSpecificPavilion(CancellationToken cancellation, int pavilionId);
        Task<List<Category>> GetCategories(CancellationToken cancellation);
        Task<List<PavilionDtoModel>> GetPavilions(int sellerId, CancellationToken cancellation);
        Task<bool> RemoveProduct(int id, CancellationToken cancellation);
    }
}