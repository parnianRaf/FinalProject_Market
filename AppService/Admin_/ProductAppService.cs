using System;
using AppCore.DtoModels.Product;
using Repositories.Repository.ProductRepository;

namespace AppService.Admin_
{
	public class ProductAppService
	{
        #region field
        private readonly IProductRepository _productRepository;
        #endregion

        #region ctor
        public ProductAppService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion

        #region Implementation
        public async Task<DetailedProductDto> GetProduct(int id, CancellationToken cancellation)
        {
            return await _productRepository.GetProduct(id, cancellation);
        }

        public async Task<List<DetailedProductDto>> GetAllProducts(int sellerId, CancellationToken cancellation)
        {
            return await _productRepository.GetAllProducts(cancellation, sellerId);
        }

        public async Task<bool> EditProduct(DetailedProductDto productDto, CancellationToken cancellation)
        {
            return await _productRepository.EditProduct(productDto, cancellation);
        }

        public async Task<bool> RemoveProduct(int id, CancellationToken cancellation)
        {
            return await _productRepository.RemoveProduct(id, cancellation);
        }

        public async Task AcceptProduct(int id, CancellationToken cancellation)
        {
            await _productRepository.AcceptProduct(id, cancellation);
        }
        #endregion
    }
}

