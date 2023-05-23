using System;
using AppCore;
using AppCore.AppServices.Seller.Query;
using Repositories.Repository.ProductRepository;

namespace AppService.Seller.Query
{
    public class GetCategories : IGetCategories
    {
        #region field
        private readonly ICategoryRepository _categoryReppository;
        #endregion

        #region ctor
        public GetCategories(ICategoryRepository categoryReppository)
        {
            _categoryReppository = categoryReppository;
        }

        #endregion
        #region Implemntation
        public async Task<List<Category>> Execute(CancellationToken cancellation)
        {
            return await _categoryReppository.GetCategories(cancellation);
        }
        #endregion
    }
}

