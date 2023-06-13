using System;
using AppCore;
using AppCore.Contracts.Services;
using AppCore.DtoModels.Auction;
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
        //private readonly IAuctionService _auctionService;
        private readonly IAuctionRepository _auctionRepository;
        private readonly IIdGeneratorService _idGeneratorService;
        private readonly IAccountServices _accountService;
        private readonly IOfferRepository _offerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductAppService _productAppService;
        #endregion

        #region ctor
        public AuctionAppService(IAuctionRepository auctionRepository, IIdGeneratorService idGeneratorService,
            IAccountServices accountService, IMapper mapper, IProductRepository productRepository
            , IProductAppService productAppService, IOfferRepository offerRepository)
        {
            _auctionRepository = auctionRepository;
            _idGeneratorService = idGeneratorService;
            //_auctionService = auctionService;
            _accountService = accountService;
            _mapper = mapper;
            _productRepository = productRepository;
            _productAppService = productAppService;
            _offerRepository = offerRepository;
        }
        #endregion

        #region Implementation
        public async Task AddAuction(AddAuctionDto auctionDto, CancellationToken cancellation)
        {
            int id = _idGeneratorService.Execute<DetailedAuctionDto>(await _auctionRepository.GetAllPaidOrUnPaidAuctions(cancellation));
            int sellerId = _accountService.GetCurrentUser();
            Auction auction=_mapper.Map<Auction>(auctionDto);
            List<Product> products =await _productRepository.GetAllProducts(auctionDto.ProductDtoIds,cancellation,sellerId);
            await _auctionRepository.AddAuction(id,sellerId,products,auction,cancellation);
        }

        public async Task AuctionOperation(int auctionId,CancellationToken cancellation,Double medalDiscount)
        {
            Auction auction = await _auctionRepository.GetAuction(auctionId, cancellation);
            while(auction.StartTime<DateTime.Now && DateTime.Now<auction.EndTime)
            {
                List<Offer> offers = await _offerRepository.GetAuctionOffers(auctionId, cancellation);
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
            return await _auctionRepository.GetAllAuctions(cancellation);
        }

        public async Task<DetailedAuctionDto> GetAuction(int id, CancellationToken cancellation)
        {
            return await _auctionRepository.GetDetailedAuction(id, cancellation);
        }

        public async Task<bool> AcceptComment(int auctionId, CancellationToken cancellation)
        {
            return await _auctionRepository.AcceptComment(auctionId, cancellation);
        }

        public async Task<bool> RejectComment(int auctionId, CancellationToken cancellation)
        {
            return await _auctionRepository.RejectComment(auctionId, cancellation);
        }

    
        #endregion

    }
}

