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
        private readonly IProductRepository _productRepository;
        #endregion

        #region ctor
        public AuctionAppService(IAuctionRepository auctionRepository, IIdGeneratorService idGeneratorService, IAccountServices accountService, IMapper mapper = null, IProductRepository productRepository = null)
        {
            _auctionRepository = auctionRepository;
            _idGeneratorService = idGeneratorService;
            //_auctionService = auctionService;
            _accountService = accountService;
            _mapper = mapper;
            _productRepository = productRepository;
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

        public async Task<List<DetailedAuctionDto>> GetAllAuctions(CancellationToken cancellation)
        {
            return await _auctionRepository.GetAllAuctions(cancellation);
        }

        public async Task<DetailedAuctionDto> GetAuction(int id, CancellationToken cancellation)
        {
            return await _auctionRepository.GetAuction(id, cancellation);
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

