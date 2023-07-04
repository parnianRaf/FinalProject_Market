using System;
using System.Diagnostics;
using AppCore;
using AppCore.DtoModels.Offer;
using Repositories.Repository.ProductRepository;

namespace Service
{
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository _offerRepository;

        public OfferService(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public async Task AddOffer(int offerId, User customer,Auction auction ,Offer offerDto, CancellationToken cancellation)
        {
            await _offerRepository.AddOffer(offerId, customer, auction,offerDto, cancellation);
        }

        public async Task<List<Offer>> GetAuctionOffers(int auctionId, CancellationToken cancellationToken)
        {
            return await _offerRepository.GetAuctionOffers(auctionId, cancellationToken);
        }

        public async Task<List<T>> GetAllOffers<T>(CancellationToken cancellation)
        {
            return await _offerRepository.GetAllOffers<T>(cancellation);
        }

        public async Task<bool> IsOfferAccepted(DetailedOfferDto offerDto,Auction auction,CancellationToken cancellation)
        {
            bool result = DateTime.Now > auction.StartTime && auction.EndTime > DateTime.Now && offerDto.Price > auction.OfferSubmitWithPrice;
            return result ;
        }

    }
}

