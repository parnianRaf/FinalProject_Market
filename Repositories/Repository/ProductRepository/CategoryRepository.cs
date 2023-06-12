using System;
using AppCore;
using AppCore.DtoModels;
using AppCore.DtoModels.Category;
using AppCore.DtoModels.Product;
using AppSqlDataBase;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Repository.ProductRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        #region field
        private readonly MarketContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region ctor
        public CategoryRepository(MarketContext context
            , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Implementation
        public async Task AddCategory(CategoryDtoModel categoryDto, CancellationToken cancellation)
        {
            Category category = _mapper.Map<Category>(categoryDto);
            category.CreateAt = DateTime.Now;
            //category.CreatedBy= .

            _context.Categories.Add(category);
            await _context.SaveChangesAsync(cancellation);
        }

        public async Task<CategoryDtoModel> GetCategory(int id, CancellationToken cancellation)
        {
            return _mapper.Map<CategoryDtoModel>( await _context.Categories.AsNoTracking().Where(p => p.Id == id).FirstOrDefaultAsync(cancellation)) ?? new CategoryDtoModel();
        }

        public async Task<bool> EditCategory(CategoryDtoModel categoryDto, CancellationToken cancellation)
        {
            bool result = false;
            Category? category = await _context.Categories.Where(p => p.Id == categoryDto.Id).FirstOrDefaultAsync(cancellation);
            if (category != null)
            {
                _context.Categories.Update(category);
                category.ModifiedAt = DateTime.Now;
                //category.ModifiedBy
                await _context.SaveChangesAsync();
                return !result;
            }
            return result;
        }

        public async Task<bool> RemoveCategory(int id, CancellationToken cancellation)
        {
            Category? category = await _context.Categories.Where(p => p.Id == id).FirstOrDefaultAsync(cancellation);
            if (category != null)
            {
                try
                {
                    category.IsDeleted = true;
                    category.DeleteAt = DateTime.Now;
                    //product.DeletedBy
                    var res = _context.Categories.Update(category);
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;

                }


            }
            return false;


        }

        public async Task<List<Category>> GetCategories(CancellationToken cancellation)
        {
            return await _context.Categories.AsNoTracking().ToListAsync(cancellation);
        }
        #endregion

    }
}

