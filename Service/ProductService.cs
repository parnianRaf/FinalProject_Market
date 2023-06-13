using System;
using AppCore.DtoModels.Auction;
using AppCore.DtoModels.Product;
using Repositories.Repository.ProductRepository;

namespace Service
{
    public class ProductService : IProductService
    {
        #region field
        private readonly ProductRepository _productRepository;
        #endregion
        #region ctor
        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion
        #region Implementation


        public List<String> GetProductNames(List<DetailedProductDto> productDtos)
        {
            return productDtos.Select(p => p.ProductName).ToList() ?? new List<String>();
        }

        //public async  Task<List<Product>> GetProducts(int sellerId,List<string> productNames,CancellationToken cancellation)
        //{
        //    return await _productRepository.GetAllProducts(productNames, cancellation, sellerId);
        //}
        #endregion
    }
}

