using AppCore;
using AppCore.DtoModels.Category;

namespace Repositories.Repository.ProductRepository
{
    public interface ICategoryRepository
    {
        Task AddCategory(CategoryDtoModel categoryDto, CancellationToken cancellation);
        Task<bool> EditCategory(CategoryDtoModel categoryDto, CancellationToken cancellation);
        Task<CategoryDtoModel> EditGetCategory(int id, CancellationToken cancellation);
        Task<List<Category>> GetCategories(CancellationToken cancellation);
        Task<bool> RemoveCategory(int id, CancellationToken cancellation);
    }
}