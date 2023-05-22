using AppCore;
using AppCore.DtoModels.Product;

namespace Repositories.Repository.ProductRepository
{
    public interface IProductRepository
    {
        Task AddProduct(AddProductDto productDto, CancellationToken cancellation);



        #region Category
        Task<List<Category>> GetCategories(CancellationToken cancellation);
        #endregion
    }
}