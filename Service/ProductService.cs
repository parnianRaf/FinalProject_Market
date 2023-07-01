using System;
using AppCore;
using AppCore.DtoModels.Auction;
using AppCore.DtoModels.Product;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.Repository.ProductRepository;

namespace Service
{
    public class ProductService : IProductService
    {
        #region field
        private readonly IProductRepository _productRepository;
        #endregion

        #region ctor
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion

        #region Implementation
        public List<String> GetProductNames(List<DetailedProductDto> productDtos)
        {
            return productDtos.Select(p => p.ProductName).ToList() ?? new List<String>();
        }

        public async Task AddProduct(int id, int sellerId, int categoryId, int? pavilionId, string dataBaseFileName, Category category, Product product, CancellationToken cancellation)
        {
            await _productRepository.AddProduct(id, sellerId, categoryId, pavilionId, dataBaseFileName, category, product, cancellation);
        }

        public async Task<List<DetailedProductDto>> GetAllProducts(CancellationToken cancellation, int SellerId)
        {
            return await _productRepository.GetAllProducts(cancellation, SellerId);
        }

        public async Task<List<DetailedProductDto>> GetCategoryProducts(int categoryId, CancellationToken cancellation)
        {
            return await _productRepository.GetCategoryProducts(categoryId, cancellation);
        }

        public async Task<List<DetailedProductDto>> GetAllProducts(CancellationToken cancellation)
        {
            return await _productRepository.GetAllProducts(cancellation);
        }
        public async Task<List<Product>> GetAllProducts(List<int> Ids, CancellationToken cancellation, int SellerId)
        {
            return await _productRepository.GetAllProducts(Ids, cancellation, SellerId);
        }

        public async Task<Product> GetEntityProduct(int id, CancellationToken cancellation)
        {
            return await _productRepository.GetEntityProduct(id, cancellation);
        }

        public async Task<DetailedProductDto> GetProduct(int id, CancellationToken cancellation)
        {
            return await _productRepository.GetProduct(id, cancellation);
        }

        public async Task<bool> EditProduct(DetailedProductDto productDto, CancellationToken cancellation)
        {
            return await _productRepository.EditProduct(productDto, cancellation);
        }

        public async Task<bool> RemoveProduct(int id, CancellationToken cancellation)
        {
            return await _productRepository.RemoveProduct(id, cancellation);
        }

        public async Task<bool> AcceptProduct(int id, CancellationToken cancellation)
        {
            return await _productRepository.AcceptProduct(id, cancellation);
        }
        #endregion
    }
}

