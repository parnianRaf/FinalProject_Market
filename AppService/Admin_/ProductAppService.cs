using System;
using AppCore;
using AppCore.Contracts.AppServices.Account;
using AppCore.DtoModels.Category;
using AppCore.DtoModels.Product;
using Repositories.Repository.ProductRepository;
using Service;

namespace AppService.Admin_
{
    public class ProductAppService : IProductAppService
    {
        #region field
        private readonly IProductRepository _productRepository;
        private readonly ICategoryService _categoryService;
        private readonly IMapServices _mapServices;
        #endregion

        #region ctor
        public ProductAppService(IProductRepository productRepository,
            ICategoryService categoryService, IMapServices mapServices)
        {
            _productRepository = productRepository;
            _categoryService = categoryService;
            _mapServices = mapServices;
        }
        #endregion

        #region Implementation

        public async Task<List<CategoryDtoModel>> GetCategories(CancellationToken cancellation)
        {
            List<Category> categories = await _categoryService.GetAllCategories(cancellation);
            return _mapServices.MapCategory(categories);
        }


        //public async Task<bool> AddProduct()
        //{

        //}














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

