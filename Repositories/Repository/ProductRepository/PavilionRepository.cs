using System;
using AppCore;
using AppCore.DtoModels;
using AppCore.DtoModels.Category;
using AppCore.DtoModels.Product;
using AppSqlDataBase;
using AutoMapper;
using ExtensionMethods;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Repository.ProductRepository
{
    public class PavilionRepository :IPavilionRepository
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

        public async Task<bool> AcceptPavilion(int pavilionId, CancellationToken cancellation)
        {
            bool result = false;
            Pavilion? order = await _context.Pavilions.Where(p => p.Id == pavilionId).FirstOrDefaultAsync(cancellation);
            if (order != null)
            {
                order.IsAccepted = true;
                _context.Pavilions.Update(order);
                order.ModifiedAt = DateTime.Now;
                //product.ModifiedBy
                await _context.SaveChangesAsync();
                return !result;
            }
            return result;
        }

        public async Task<bool> RejectPavilion(int pavilionId, CancellationToken cancellation)
        {
            bool result = false;
            Pavilion? order = await _context.Pavilions.Where(p => p.Id == pavilionId).FirstOrDefaultAsync(cancellation);
            if (order != null)
            {
                order.IsAccepted = false;
                _context.Pavilions.Update(order);
                order.ModifiedAt = DateTime.Now;
                //product.ModifiedBy
                await _context.SaveChangesAsync();
                return !result;
            }
            return result;
        }

        public async Task<PavilionDtoModel> GetPavilion(int id, CancellationToken cancellation)
        {
            PavilionDtoModel? pavilionDto = await _context.Pavilions.Where(p => p.Id == id).Select(p => new PavilionDtoModel()
            {
                 Id=p.Id,
                  AcceptedAt=p.AcceptedAt.IranianDate(),
                   CreatedAt=p.CreatedAt.IranianDate2(),
                    DeletedAt=p.DeletedAt.IranianDate(),
                     IsAccepted=p.IsAccepted,
                      IsDeleted=p.IsDeleted,
                       SellerName=p.User.FullNameToString(),
                        Title=p.Title


            }).FirstOrDefaultAsync(cancellation);
            var result = pavilionDto;
            if (pavilionDto != null)
            {
                return pavilionDto;
            }
            return new PavilionDtoModel();
        }

        public async Task<bool> EditPavilion(PavilionDtoModel pavilionDto, CancellationToken cancellation)
        {
            bool result = false;
            Pavilion? pavilion = await _context.Pavilions.Where(p => p.Id == pavilionDto.Id).FirstOrDefaultAsync(cancellation);
            if (pavilion != null)
            {
                pavilion.Title = pavilionDto.Title;
                pavilion.ModifiedAt = DateTime.Now;
                _context.Pavilions.Update(pavilion);
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
                    pavilion.IsAccepted = false;
                    pavilion.DeletedAt = DateTime.Now;
                    //pavilion.DeletedBy
                    var res = _context.Pavilions.Update(pavilion);
                    await _context.SaveChangesAsync(cancellation);
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;

                }


            }
            return false;


        }

        public async Task<List<PavilionDtoModel>> GetSellerPavilions(int sellerId, CancellationToken cancellation)
        {
            return  _mapper.Map<List<PavilionDtoModel>>(await _context.Pavilions.Where(p => p.UserId == sellerId).AsNoTracking().ToListAsync(cancellation));
        }

        public async Task<List<Pavilion>> GetPavilions(CancellationToken cancellation)
        {
            return await _context.Pavilions.AsNoTracking().ToListAsync(cancellation);
        }
        #endregion
    }
}

