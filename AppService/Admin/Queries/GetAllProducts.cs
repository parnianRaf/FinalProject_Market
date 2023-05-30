using System;
using AppCore.DtoModels.Product;
using Repositories.Repository.ProductRepository;

namespace AppService.Admin.Queries
{
    public class GetAllSellerProducts : IGetAllSellerProducts
    {
        #region field
        private readonly IProductRepository _productRepository;
        #endregion

        #region ctor
        public GetAllSellerProducts(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion

        #region Implementation
        public async Task<List<DetailedProductDto>> Execute(int sellerId, CancellationToken cancellation)
        {
            return await _productRepository.GetAllProducts(cancellation, sellerId);
        }
        #endregion

    }
}

