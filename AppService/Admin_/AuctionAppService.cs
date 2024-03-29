﻿using System;
using AppCore;
using AppCore.Contracts.Services;
using AppCore.DtoModels.Auction;
using AppCore.DtoModels.DirectOrder;
using AppCore.DtoModels.Offer;
using AppCore.DtoModels.Product;
using AutoMapper;
using Repositories.Repository.ProductRepository;
using Service;

namespace AppService.Admin_
{
    public class AuctionAppService : IAuctionAppService
    {
        #region field
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly IAuctionService _auctionService;
        private readonly IOfferService _offerService;
        private readonly IIdGeneratorService _idGeneratorService;
        private readonly IAccountAppServices _account;
        private readonly IAccountServices _accountService;
        private readonly IProductAppService _productAppService;
        private readonly IAuctionCacheAppService _auctionCacheApp;
        #endregion

        #region ctor
        public AuctionAppService(IIdGeneratorService idGeneratorService,
            IAccountServices accountService, IMapper mapper
            , IProductAppService productAppService, IOfferService offerService, IAccountAppServices account,
            IAuctionService auctionService, IProductService productService, IAuctionCacheAppService auctionCacheApp)
        {
            _idGeneratorService = idGeneratorService;
            _accountService = accountService;
            _mapper = mapper;
            _productAppService = productAppService;
            _offerService = offerService;
            _account = account;
            _auctionService = auctionService;
            _productService = productService;
            _auctionCacheApp = auctionCacheApp;
        }
        #endregion

        #region Implementation
        public async Task AddOffer(DetailedOfferDto offerDto,CancellationToken cancellation)
        {
            Auction auction = await _auctionService.GetAuction(offerDto.AuctionId, cancellation);
            offerDto.IsAccepted = await _offerService.IsOfferAccepted(offerDto,auction, cancellation);
            if (offerDto.IsAccepted)
            {
                auction.OfferSubmitWithPrice = offerDto.Price;
            }
            int offerId = _idGeneratorService.Execute<Offer>(await _offerService.GetAllOffers<Offer>(cancellation));
            User customer =await _account.GetUser<User>(cancellation);
            offerDto.SubmitAt = DateTime.UtcNow;
            Offer offer=_mapper.Map<Offer>(offerDto);
            await _offerService.AddOffer(offerId, customer,auction, offer, cancellation);
        }

        public async Task<Auction> AddAuction(AddAuctionDto auctionDto, CancellationToken cancellation)
        {
            int id = _idGeneratorService.Execute<Auction>(await _auctionService.GetAllEntityAuction(cancellation));
            int sellerId = _accountService.GetCurrentUser();
            Auction auction=_mapper.Map<Auction>(auctionDto);
            List<Product> products =await _productService.GetAllProducts(auctionDto.ProductDtoIds,cancellation,sellerId);
            return await _auctionService.AddAuction(id,sellerId,products,auction,cancellation);
        }

        public async Task UpdateAuction(Auction auction,CancellationToken cancellation)
        {
            await _auctionService.UpdateAuction(auction, cancellation);
        }

        public async Task UpdateAuctions(AuctionTime auctions,CancellationToken cancellation)
        {
            Auction auction = await _auctionService.GetAuction(auctions.Id, cancellation);
            auction.IsActive = (auctions.StartTime < DateTime.Now && DateTime.Now < auctions.EndTime);
            if (auction.IsActive==false)
            {
                auction.IsFinished = true;
                auction.FinishedAt = DateTime.Now;
                if (auction.Offers.Any())
                {
                  auction.FinalPrice = auction.Offers.OrderBy(o => o.SubmitAt).OrderBy(o => o.Price).FirstOrDefault().Price ;
                  auction.AcceptedCustomerId = auction.Offers.OrderBy(o => o.SubmitAt).OrderBy(o => o.Price).FirstOrDefault().UserId;

                }
            }
            await UpdateAuction(auction, cancellation);
        }

        public async Task AuctionOperation(int auctionId,CancellationToken cancellation,Double medalDiscount)
        {
            Auction auction = await _auctionService.GetAuction(auctionId, cancellation);
            while(auction.StartTime<DateTime.Now && DateTime.Now<auction.EndTime)
            {
                List<Offer> offers = await _offerService.GetAuctionOffers(auctionId, cancellation);
                Offer acceptedOffer =offers.OrderBy(o=>o.Price).FirstOrDefault() ?? new Offer();
                auction.AcceptedCustomerId = acceptedOffer.UserId;
                auction.OfferSubmitWithPrice =acceptedOffer.Price * Convert.ToDecimal(medalDiscount);
                auction.FinishedAt = DateTime.Now;
            }
            if(!auction.Offers.Any())
            {
                auction.Products.ForEach(p => _productAppService.RemoveProduct(p.Id, cancellation));
            }

        }

        public async Task<List<DetailedAuctionDto>> GetAllAuctions(CancellationToken cancellation)
        {
            return await _auctionService.GetAllAuctions(cancellation);
        }

        public async Task<List<DetailedAuctionDto>> GetAllAvailableDetailedAuction(CancellationToken cancellation)
        {
            return await _auctionService.GetAllAvailableAuctions(cancellation);
        }

        public async Task<List<DetailedAuctionDto>> GetAllPaidAuctions(CancellationToken cancellation)
        {
            User user = await _account.GetUser<User>(cancellation) ?? new User();
            return await _account.RoleCurrentUser(cancellation) == 1 ? await _auctionService.GetAllCustomerAuctions(user.Id, cancellation) :
                await _auctionService.GetAllSuccededSellerAuctions(user.Id, cancellation);
        }

        public async Task<List<Auction>> GetAllEntityAuction(CancellationToken cancellation)
        {
            return await _auctionService.GetAllEntityAuction(cancellation);
        }

        public async Task<DetailedAuctionDto> GetAuction(int id, CancellationToken cancellation)
        {
            return await _auctionService.GetDetailedAuction(id, cancellation);
        }

        public async Task<bool> AcceptComment(int auctionId, CancellationToken cancellation)
        {
            return await _auctionService.AcceptComment(auctionId, cancellation);
        }

        public async Task<bool> RejectComment(int auctionId, CancellationToken cancellation)
        {
            return await _auctionService.RejectComment(auctionId, cancellation);
        }

        public async Task<List<DateTime>> GetStartDateTimes(CancellationToken cancellation)
        {
            List<Auction> auctions = await _auctionCacheApp.GetCache(cancellation);
            return auctions.Select(a => a.StartTime).ToList();
        }
        #endregion

    }
}

