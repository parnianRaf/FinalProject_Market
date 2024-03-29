﻿using System;
using AppCore;
using AppCore.Contracts.AppServices;
using AppCore.Contracts.Services;
using AppCore.DtoModels.Category;
using AppCore.DtoModels.Product;
using Repositories.Repository.ProductRepository;
using Service;

namespace AppService.Admin_
{
    public class ProductAppService : IProductAppService
    {
        #region field
        private readonly ICategoryService _categoryService;
        private readonly IMapServices _mapServices;
        private readonly ICookieService _setCookieService;
        private readonly IIdGeneratorService _idGeneratorService;
        private readonly IAccountServices _accountService;
        private readonly IImageService _imageService;
        private readonly IProductService _productService;

        #endregion

        #region ctor
        public ProductAppService(ICategoryService categoryService, IMapServices mapServices,
            ICookieService setCookieService, IIdGeneratorService idGeneratorService,
            IAccountServices accountService, IImageService imageService, IProductService productService)
        {
            _categoryService = categoryService;
            _mapServices = mapServices;
            _setCookieService = setCookieService;
            _idGeneratorService = idGeneratorService;
            _accountService = accountService;
            _imageService = imageService;
            _productService = productService;
            //_auctionService = auctionService;
            //_productService = productService;
        }
        #endregion

        #region Implementation

        public async Task<List<CategoryDtoModel>> GetCategories(CancellationToken cancellation)
        {
            List<Category> categories = await _categoryService.GetAllCategories(cancellation);
            return _mapServices.MapCategory(categories);
        }

        public async Task<CategoryDtoModel> GetCategory(int id,CancellationToken cancellation)
        {
            CategoryDtoModel categoryDto= await _categoryService.GetCategory(id, cancellation);
            _setCookieService.SetCookies(id, "CategoryId");
            return categoryDto;
        }

        public async Task AddProduct(AddProductDto productDto,CancellationToken cancellation)
        {
            int id = _idGeneratorService.Execute<DetailedProductDto>(await GetAllProducts(cancellation));
            int sellerId = _accountService.GetCurrentUser();
            int categoryId = Convert.ToInt16(_setCookieService.ReadCookies("CategoryId"));
            Category category =_mapServices.MapCategory(await _categoryService.GetCategory(categoryId,cancellation));
            int  pavilionId= Convert.ToInt16(_setCookieService.ReadCookies("PavilionId"));
            Product product = _mapServices.MapProduct(productDto);
            string filePath= _imageService.GetFilePath(productDto.ProductName,productDto.fileImages);
            await _productService.AddProduct(id,sellerId, categoryId, pavilionId,filePath,category,product, cancellation);
        }

        public async Task<List<DetailedProductDto>> GetAllSellerProducts( CancellationToken cancellation)
        {
            int sellerId = _accountService.GetCurrentUser();
            return await _productService.GetAllProducts(cancellation, sellerId);
        }

        public async Task<List<DetailedProductDto>> GetCategoryProducts(int categoryId,CancellationToken cancellation)
        {
            return await _productService.GetCategoryProducts(categoryId, cancellation);
        }

        public async Task<List<DetailedProductDto>> GetFirstPageProducts(CancellationToken cancellation)
        {
            List<DetailedProductDto> productDtos = await _productService.GetAllProducts(cancellation);
            return productDtos.Skip(29).Take(6).ToList();
        }


        public async Task<List<DetailedProductDto>> GetAllProducts(int sellerId, CancellationToken cancellation)
        {
            return await _productService.GetAllProducts(cancellation, sellerId);
        }


        public async Task<Product> GetEntityProduct(int id, CancellationToken cancellation)
        {
            return await  _productService.GetEntityProduct(id, cancellation);
        }

        public async Task<DetailedProductDto> GetProduct(int id, CancellationToken cancellation)
        {
            return await _productService.GetProduct(id, cancellation);
        }

        public async Task<List<DetailedProductDto>> GetAllProducts( CancellationToken cancellation)
        {
            return await _productService.GetAllProducts(cancellation);
        }


        public async Task<bool> EditProduct(DetailedProductDto productDto, CancellationToken cancellation)
        {
            return await _productService.EditProduct(productDto, cancellation);
        }

        public async Task<bool> RemoveProduct(int id, CancellationToken cancellation)
        {
            return await _productService.RemoveProduct(id, cancellation);
        }

        public async Task AcceptProduct(int id, CancellationToken cancellation)
        {
            await _productService.AcceptProduct(id, cancellation);
        }
        #endregion
    }
}

