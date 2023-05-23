using System;
using System.Collections.Generic;
using AppCore;
using AppCore.DtoModels;
using AppCore.DtoModels.Auction;
using AppCore.DtoModels.Offer;
using AppCore.DtoModels.Product;
using AppSqlDataBase;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Repository.ProductRepository
{
    public class AuctionRepository : IAuctionRepository
    {
        #region field
        private readonly MarketContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region ctor
        public AuctionRepository(MarketContext context
            , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Implementation
        public async Task AddAuction(AddAuctionDto auctionDto, CancellationToken cancellation)
        {
            Auction auction = _mapper.Map<Auction>(auctionDto);
            auction.CreateAt = DateTime.Now;
            //product.CreatedBy= .
            _context.Auctions.Add(auction);
            await _context.SaveChangesAsync(cancellation);

        }

        //moghe buissiness hatman baiad havasemon bashe ke datetime now o start auction moghayese shavad

        public async Task<EditAuctionDto> EditGetAuction(int id, CancellationToken cancellation)
        {
            Auction? auction = await _context.Auctions.Where(p => p.Id == id).FirstOrDefaultAsync(cancellation);
            if (auction != null)
            {
                return _mapper.Map<EditAuctionDto>(auction);
            }
            return new EditAuctionDto();
        }

        public async Task<bool> EditAuction(EditAuctionDto auctionDto, CancellationToken cancellation)
        {
            bool result = false;
            Auction? auction = await _context.Auctions.Where(p => p.Id == auctionDto.Id).FirstOrDefaultAsync(cancellation);
            if (auction != null)
            {
                _context.Auctions.Update(auction);
                auction.ModeifiedAt = DateTime.Now;
                //auction.ModifiedBy
                await _context.SaveChangesAsync();
                return !result;
            }
            return result;
        }

        public async Task<bool> RemoveAuction(int id, CancellationToken cancellation)
        {
            Auction? auction = await _context.Auctions.Where(p => p.Id == id).FirstOrDefaultAsync(cancellation);
            if (auction != null)
            {
                try
                {
                    auction.IsDeleted = true;
                    auction.DeleteAt = DateTime.Now;
                    //auction.DeletedBy
                    var res = _context.Auctions.Update(auction);
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
        public async Task<List<DetailedAuctionDto>> GetAllSellerAuctions(CancellationToken cancellation, int SellerId)
        {
            List<Auction> auctions = await _context.Auctions.Where(p => p.SellerId == SellerId).ToListAsync(cancellation);
            return _mapper.Map<List<DetailedAuctionDto>>(auctions);
        }

        //selerId baiad hamon htttpContext.User.Id????????????????????????!!!!!!!!!!!
        public async Task<List<DetailedAuctionDto>> GetAllCustomersAuctions(CancellationToken cancellation, int CustomerId)
        {
            List<Auction> auctions = await _context.Auctions.Where(p => p.AcceptedCustomerId == CustomerId).ToListAsync(cancellation);
            return _mapper.Map<List<DetailedAuctionDto>>(auctions);
        }

        //public async Task<List<DetailedProductDto>> GetProductsInSpecificAuction(int sellerId, int auctionId, CancellationToken cancellation)
        //{
        //    List<Product> products = await _context.Products.Where(p => p.SellerId == sellerId && p.AuctionId == auctionId).ToListAsync();
        //    return _mapper.Map<List<DetailedProductDto>>(products);
        //}

        public async Task<List<DetailedOfferDto>> GetOffersInSpecificSellerAuction(int sellerId, int auctionId, CancellationToken cancellation)
        {
            List<Offer> offers = await _context.Offers.Where(o => o.Auction.Id == auctionId && o.Auction.SellerId == sellerId).ToListAsync();
            return _mapper.Map<List<DetailedOfferDto>>(offers);
        }

        public async Task<List<DetailedOfferDto>> GetOffersInSpecificCustomerAuction(int customerId, int auctionId, CancellationToken cancellation)
        {
            List<Offer> offers = await _context.Offers.Where(o => o.Auction.Id == auctionId && o.CustomerId == customerId).ToListAsync();
            return _mapper.Map<List<DetailedOfferDto>>(offers);
        }

        public async Task<bool> AddCommentByCustomer(int auctionId, int customerId, string comment, CancellationToken cancellation)
        {
            bool result = false;
            Auction? auction = await _context.Auctions.Where(o => o.Id == auctionId && o.AcceptedCustomerId == customerId).FirstOrDefaultAsync(cancellation);
            if (auction != null)
            {
                auction.CommentByCostumer = comment;
                _context.Auctions.Update(auction);
                await _context.SaveChangesAsync();
                return true;
            }
            return result;

        }

        public Task<List<DetailedAuctionDto>> GetAllAuctions(CancellationToken cancellation, int SellerId)
        {
            throw new NotImplementedException();
        }

        public Task<List<DetailedOfferDto>> GetOffersInSpecificAuction(int sellerId, int auctionId, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }


        #endregion

    }
}

