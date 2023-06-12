using System;
using AppCore;
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
        #endregion
    }
}

