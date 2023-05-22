using System;
using AppCore;
using AppCore.AppServices.Seller.Query;
using Repositories.Repository.ProductRepository;

namespace AppService.Seller.Query
{
    public class GetCategories : IGetCategories
    {
        #region field
        private readonly IProductRepository _productRepository;
        #endregion

        #region ctor
        public GetCategories(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        #endregion
        #region Implemntation
        public async Task<List<Category>> Execute(CancellationToken cancellation)
        {
            return await _productRepository.GetCategories(cancellation);
        }
        #endregion
    }
}

