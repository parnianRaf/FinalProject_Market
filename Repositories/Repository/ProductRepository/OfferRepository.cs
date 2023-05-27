using System;
using AppCore;
using AppCore.DtoModels.Offer;
using AppCore.DtoModels.Product;
using AppSqlDataBase;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Repository.ProductRepository
{
    public class OfferRepository 
    {
        #region field
        private readonly MarketContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region ctor
        public OfferRepository(MarketContext context
            , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Implementation

        //dar buissines barname gofte shavad ke harmoghe offer sabt shod moghayese sorat girad.
        public async Task AddOffer(AddOfferDto offerDto, CancellationToken cancellation)
        {
            Offer offer = _mapper.Map<Offer>(offerDto);
            offer.CreatedAt = DateTime.Now;
            //offer.CreatedBy= .
            _context.Offers.Add(offer);
            await _context.SaveChangesAsync(cancellation);

        }

        //moghe buissiness hatman baiad havasemon bashe ke datetime now o start auction moghayese shavad

        public async Task<EditOfferDto> EditGetOffer(int id, CancellationToken cancellation)
        {
            Offer? offer = await _context.Offers.Where(p => p.Id == id).FirstOrDefaultAsync(cancellation);
            if (offer != null)
            {
                return _mapper.Map<EditOfferDto>(offer);
            }
            return new EditOfferDto();
        }

        //public async Task<bool> EditOffer(EditOfferDto offerDto, CancellationToken cancellation)
        //{
        //    bool result = false;
        //    Offer? offer = await _context.Offers.Where(p => p.Id == offerDto.Id).FirstOrDefaultAsync(cancellation);
        //    if (offer != null)
        //    {
        //        _context.Offers.Update(offer);
        //        offer.ModifiedAt = DateTime.Now;
        //        //auction.ModifiedBy
        //        await _context.SaveChangesAsync();
        //        return !result;
        //    }
        //    return result;
        //}

        //public async Task<bool> RemoveAuction(int id, CancellationToken cancellation)
        //{
        //    Offer? offer = await _context.Offers.Where(p => p.Id == id).FirstOrDefaultAsync(cancellation);
        //    if (offer != null)
        //    {
        //        try
        //        {
        //            offer.IsDeleted = true;
        //            offer.DeletedAt = DateTime.Now;
        //            //auction.DeletedBy
        //            var res = _context.Offers.Update(offer);
        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;

        //        }


        //    }
        //    return false;

        //selerId baiad hamon htttpContext.User.Id????????????????????????!!!!!!!!!!!
        //public async Task<List<DetailedOfferDto>> GetAllOffers(CancellationToken cancellation, int customerId)
        //{
        //    List<Offer> offers = await _context.Offers.Where(p => p.CustomerId == customerId).ToListAsync(cancellation);
        //    return _mapper.Map<List<DetailedOfferDto>>(offers);
        //}
        #endregion
    }





}

