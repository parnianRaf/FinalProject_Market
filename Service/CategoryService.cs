using System;
using AppCore;
using AppCore.DtoModels.Category;
using Repositories.Repository.ProductRepository;

namespace Service
{
    public class CategoryService : ICategoryService
    {
        #region field
        private readonly ICategoryRepository _categoryRepository;
        #endregion

        #region ctor
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        #endregion

        #region Implementeation
        public async Task<List<Category>> GetAllCategories(CancellationToken cancellation)
        {
            return await _categoryRepository.GetCategories(cancellation);
        }

        public async Task<CategoryDtoModel> GetCategory(int id, CancellationToken cancellation)
        {
            return await _categoryRepository.GetCategory(id, cancellation);
        }
        #endregion
    }
}

