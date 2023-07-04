using System;
using AppCore;
using AppCore.DtoModels.Offer;
using AppCore.DtoModels.Product;
using AppSqlDataBase;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Repository.ProductRepository
{
    public class OfferRepository : IOfferRepository
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
        public async Task<Offer> AddOffer(int offerId,User customer,Auction auction,Offer offerDto, CancellationToken cancellation)
        {
            offerDto.UserId = customer.Id;
            offerDto.User = customer;
            offerDto.AuctionId = auction.Id;
            offerDto.Auction = auction;
            auction.Offers.Add(offerDto);
            customer.Offers.Add(offerDto);
            await _context.Offers.AddAsync(offerDto);
            _context.Auctions.Update(auction);
            await _context.SaveChangesAsync(cancellation);
            return offerDto;
        }

        public async Task<Offer> GetAcceptedOffer(CancellationToken cancellation)
        {
            return await _context.Offers.Where(o => o.IsAccepted).FirstOrDefaultAsync(cancellation)?? new Offer();
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

        public async Task<List<Offer>> GetAuctionOffers(int auctionId, CancellationToken cancellation)
        {
            return await _context.Offers.Where(o => o.AuctionId == auctionId).ToListAsync(cancellation);
        }

        public async Task<List<T>> GetAllOffers<T>(CancellationToken cancellation)
        {
            return  _mapper.Map<List<T>>(await _context.Offers.ToListAsync(cancellation));
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

        //public async Task<List<DetailedOfferDto>> GetAllOffers(CancellationToken cancellation, int customerId)
        //{
        //    List<Offer> offers = await _context.Offers.Where(p => p.CustomerId == customerId).ToListAsync(cancellation);
        //    return _mapper.Map<List<DetailedOfferDto>>(offers);
        //}
        #endregion
    }





}

