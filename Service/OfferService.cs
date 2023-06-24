using System;
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

        public async Task AddOffer(int offerId, User customer, DetailedOfferDto offerDto, CancellationToken cancellation)
        {
            await _offerRepository.AddOffer(offerId, customer, offerDto, cancellation);
        }

        public async Task<List<Offer>> GetAuctionOffers(int auctionId, CancellationToken cancellationToken)
        {
            return await _offerRepository.GetAuctionOffers(auctionId, cancellationToken);
        }

        public async Task<List<T>> GetAllOffers<T>(CancellationToken cancellation)
        {
            return await _offerRepository.GetAllOffers<T>(cancellation);
        }

        public async Task<bool> IsOfferAccepted(DetailedOfferDto offerDto,CancellationToken cancellation)
        {
            return DateTime.Now > offerDto.Auction.StartTime && offerDto.Auction.EndTime > DateTime.Now && await CheckPrice(offerDto.Price, cancellation);
        }

        public async Task<bool> CheckPrice(decimal price,CancellationToken cancellation)
        {
            Offer acceptedOffer = await _offerRepository.GetAcceptedOffer(cancellation);
            return price > acceptedOffer.Price;
        }

        public async Task<decimal> PriceCheck(decimal price,CancellationToken cancellation)
        {
            Offer acceptedOffer =await _offerRepository.GetAcceptedOffer(cancellation);
            return acceptedOffer.Price < price ? price : acceptedOffer.Price;
        }
    }
}

