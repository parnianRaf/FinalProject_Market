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
    public class PavilionRepository : IPavilionRepository
    {
        #region field
        private readonly MarketContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region ctor
        public PavilionRepository(MarketContext context
            , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Implementation
        public async Task AddPavilion(PavilionDtoModel pavilionDto, CancellationToken cancellation)
        {
            Pavilion pavilion = _mapper.Map<Pavilion>(pavilionDto);
            pavilion.CreatedAt = DateTime.Now;
            //pavilion.CreatedBy= .

            _context.Pavilions.Add(pavilion);
            await _context.SaveChangesAsync(cancellation);
        }

        public async Task<PavilionDtoModel> EditGetPavilion(int id, CancellationToken cancellation)
        {
            Pavilion? pavilion = await _context.Pavilions.Where(p => p.Id == id).FirstOrDefaultAsync(cancellation);
            if (pavilion != null)
            {
                return _mapper.Map<PavilionDtoModel>(pavilion);
            }
            return new PavilionDtoModel();
        }

        public async Task<bool> EditPavilion(PavilionDtoModel pavilionDto, CancellationToken cancellation)
        {
            bool result = false;
            Pavilion? pavilion = await _context.Pavilions.Where(p => p.Id == pavilionDto.Id).FirstOrDefaultAsync(cancellation);
            if (pavilion != null)
            {
                _context.Pavilions.Update(pavilion);
                pavilion.ModifiedAt = DateTime.Now;
                //pavilion.ModifiedBy
                await _context.SaveChangesAsync();
                return !result;
            }
            return result;
        }

        public async Task<bool> RemovePavilion(int id, CancellationToken cancellation)
        {
            Pavilion? pavilion = await _context.Pavilions.Where(p => p.Id == id).FirstOrDefaultAsync(cancellation);
            if (pavilion != null)
            {
                try
                {
                    pavilion.IsDeleted = true;
                    pavilion.DeletedAt = DateTime.Now;
                    //pavilion.DeletedBy
                    var res = _context.Pavilions.Update(pavilion);
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;

                }


            }
            return false;


        }

        public async Task<List<Pavilion>> GetPavilions(CancellationToken cancellation)
        {
            return await _context.Pavilions.ToListAsync(cancellation);
        }
        #endregion
    }
}

