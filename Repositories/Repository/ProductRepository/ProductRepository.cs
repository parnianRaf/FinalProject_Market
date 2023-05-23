using System;
using AppCore;
using AppCore.DtoModels;
using AppCore.DtoModels.Product;
using AppSqlDataBase;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Repository.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MarketContext _context;
        private readonly IMapper _mapper;
        public ProductRepository(MarketContext context
            , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        public async Task<bool> EditProduct(EditProductDto productDto, CancellationToken cancellation)
        {
            bool result = false;
            Product? product = await _context.Products.Where(p => p.Id == productDto.Id).FirstOrDefaultAsync(cancellation);
           
            if (product != null)
            {
                product = _mapper.Map<Product>(productDto);
                _context.Products.Update(product);
                product.ModifiedAt = DateTime.Now;
                //product.ModifiedBy
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
                _context.Products.Update(product);
                product.ModifiedAt = DateTime.Now;
                //product.ModifiedBy
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
                    product.IsDeleted = true;
                    product.DeletedAt = DateTime.Now;
                    //product.DeletedBy
                    var res = _context.Products.Update(product);
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;

                }


            }
            return false;


        }

        //selerId baiad hamon htttpContext.User.Id????????????????????????!!!!!!!!!!!
        public async Task<List<DetailedProductDto>> GetAllProducts(CancellationToken cancellation, int SellerId)
        {
            List<Product> products = await _context.Products.Where(p => p.SellerId == SellerId).ToListAsync(cancellation);
            return _mapper.Map<List<DetailedProductDto>>(products);
        }

        public async Task<List<DetailedProductDto>> GetAllProductsInSpecificPavilion(CancellationToken cancellation, int pavilionId)
        {
            List<Product> products = await _context.Products.Where(p => p.PavilionId == pavilionId).ToListAsync(cancellation);
            return _mapper.Map<List<DetailedProductDto>>(products);
        }


        #endregion



    }
}

