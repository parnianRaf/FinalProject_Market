﻿using System;
using AppCore;
using AppCore.DtoModels;
using AppCore.DtoModels.Product;
using AppSqlDataBase;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ExtensionMethods;
using Microsoft.AspNetCore.Identity;

namespace Repositories.Repository.ProductRepository
{
    public class ProductRepository :IProductRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
        private readonly MarketContext _context;
        private readonly IMapper _mapper;
        public ProductRepository(MarketContext context
            , IMapper mapper, IHttpContextAccessor httpContextAccessor
            , UserManager<User> userManager)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }


        #region Product
        public async Task AddProduct(AddProductDto productDto, CancellationToken cancellation)
        {
            Product product = _mapper.Map<Product>(productDto);
            product.CreatedAt = DateTime.Now;
            //product.CreatedBy= .



            //Add Image
            if (product.ImageFile.Length > 0)
            {
                string UploadDir = "/Users/parnianrafei/Documents/GitHub/FinalProject_Market/FinalProject_Market/wwwroot/Images";
                string fileName = product.ProductName + Path.GetExtension(product.ImageFile.FileName);
                string filePath = Path.Combine(UploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await product.ImageFile.CopyToAsync(fileStream);
                    product.filePathSource = filePath;
                }
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync(cancellation);

            //amaliat ra dar service
        }

        public async Task<EditProductDto> EditGetProduct(int id, CancellationToken cancellation)
        {
            Product? product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync(cancellation);
            if (product != null)
            {
                return _mapper.Map<EditProductDto>(product);
            }
            return new EditProductDto();
        }

        public async Task<bool> EditProduct(DetailedProductDto productDto, CancellationToken cancellation)
        {
            bool result = false;
            Product? product = await _context.Products.Where(p => p.Id == productDto.Id).FirstOrDefaultAsync(cancellation);

            if (product != null)
            {
                product.ProductName = productDto.ProductName;
                product.CategoryId = _context.Categories.FirstOrDefault(c=>c.Title==productDto.CategoryName).Id;
                product.Category = _context.Categories.FirstOrDefault(c => c.Title == productDto.CategoryName);
                product.Price = productDto.Price;
                product.ModifiedAt = DateTime.Now;
                //product.ModifiedBy
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return !result;
            }
            return result;
        }

        public async Task<bool> AcceptProduct(int id, CancellationToken cancellation)
        {
            bool result = false;
            Product? product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync(cancellation);
            if (product != null)
            {
                product.IsActive = true;
                product.IsDeleted = false;
                product.ModifiedAt = DateTime.Now;
                //product.ModifiedBy
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return !result;
            }
            return result;
        }

        public async Task<bool> RejectProduct(int id, CancellationToken cancellation)
        {
            bool result = false;
            Product? product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync(cancellation);
            if (product != null)
            {
                product.IsActive = false;
                _context.Products.Update(product);
                product.ModifiedAt = DateTime.Now;
                //product.ModifiedBy
                await _context.SaveChangesAsync();
                return !result;
            }
            return result;
        }

        public async Task<bool> RemoveProduct(int id, CancellationToken cancellation)
        {
            Product? product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync(cancellation);
            if (product != null)
            {
                try
                {
                    product.IsActive = false;
                    product.IsDeleted = true;
                    product.DeletedAt = DateTime.Now;
                    product.DeletedBy= int.Parse(_userManager.GetUserId(_httpContextAccessor.HttpContext.User));
                    var res = _context.Products.Update(product);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;

                }


            }
            return false;


        }

        public async Task<DetailedProductDto> GetProduct(int id, CancellationToken cancellation)
        {
            DetailedProductDto? productDto = await _context.Products.Where(p => p.Id == id).AsNoTracking().Select(p => new DetailedProductDto()
            {
                Id = p.Id,
                ProductName = p.ProductName,
                Price = p.Price,
                SellerFullName = p.User.FullNameToString(),
                ActivatedAt = p.AcceptedAt.IranianDate(),
                CreatedAt = p.CreatedAt.IranianDate2(),
                IsActive = p.IsActive,
                IsDeleted = p.IsDeleted,
                DeletedAt = p.DeletedAt.IranianDate(),

                CategoryName = p.Category.Title,
                //CategoryName =_context.Categories.FirstOrDefault(c=>c.Id==product.CategoryId).Title,

                filePathSource = p.filePathSource

            }).FirstOrDefaultAsync(cancellation);
            if(productDto!=null)
            {
                return productDto;
            }
       
            return new DetailedProductDto();
        }

        public async Task<List<DetailedProductDto>> GetAllProducts(CancellationToken cancellation, int SellerId) 
        {
            List<DetailedProductDto> productDtos =await  _context.Products.Where(p => p.UserId == SellerId).AsNoTracking().Select(o => new DetailedProductDto()
            {
                 Id=o.Id,
                 ProductName=o.ProductName,
                 Price=o.Price,
                 SellerFullName=o.User.FullNameToString(),
                 ActivatedAt=o.AcceptedAt.IranianDate(),
                 CreatedAt=o.CreatedAt.IranianDate2(),
                 CategoryName=o.Category.Title,
                 PavilionName=o.User.Pavilions.FirstOrDefault(p=>p.Id==o.PavilionId).Title,
                 IsActive=o.IsActive,
                 IsDeleted=o.IsDeleted,
                  DeletedAt=o.DeletedAt.IranianDate(),
                 filePathSource=o.filePathSource
            }).ToListAsync(cancellation);
            var result = productDtos;
            return productDtos;
        }

        public async Task<List<DetailedProductDto>> GetAllProductsInSpecificPavilion(CancellationToken cancellation, int pavilionId)
        {
            List<Product> products = await _context.Products.Where(p => p.PavilionId == pavilionId).AsNoTracking().ToListAsync(cancellation);
            return _mapper.Map<List<DetailedProductDto>>(products);
        }
        #endregion



    }
}

