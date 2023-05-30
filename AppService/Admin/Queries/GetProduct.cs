using System;
using AppCore.DtoModels.Product;
using Repositories.Repository.ProductRepository;

namespace AppService.Admin.Queries
{
    public class GetProduct : IGetProduct
    {
        #region field
        private readonly IProductRepository _productRepository;
        #endregion

        #region ctor
        public GetProduct(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion

        #region Implementation
        public async Task<DetailedProductDto> Execute(int id, CancellationToken cancellation)
        {
            return await _productRepository.GetProduct(id, cancellation);
        }
        #endregion

    }
}

