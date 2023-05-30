using AppCore;
using AppCore.DtoModels.Product;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Repository.ProductRepository
{
    public interface IProductRepository
    {
        Task<bool> AcceptProduct(int id, CancellationToken cancellation);
        Task AddProduct(AddProductDto productDto, CancellationToken cancellation);
        Task<EditProductDto> EditGetProduct(int id, CancellationToken cancellation);
        Task<bool> EditProduct(EditProductDto productDto, CancellationToken cancellation);
        Task<DetailedProductDto> GetProduct(int id, CancellationToken cancellation);
        Task<List<DetailedProductDto>> GetAllProducts(CancellationToken cancellation, int SellerId);
        Task<List<DetailedProductDto>> GetAllProductsInSpecificPavilion(CancellationToken cancellation, int pavilionId);
        Task<bool> RejectProduct(int id, CancellationToken cancellation);
        Task<bool> RemoveProduct(int id, CancellationToken cancellation);
    }
}