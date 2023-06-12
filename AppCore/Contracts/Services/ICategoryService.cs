using AppCore;
using AppCore.DtoModels.Category;

namespace Service
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories(CancellationToken cancellation);
        Task<CategoryDtoModel> GetCategory(int id, CancellationToken cancellation);
    }
}