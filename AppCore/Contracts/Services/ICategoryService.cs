using AppCore;

namespace Service
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories(CancellationToken cancellation);
    }
}