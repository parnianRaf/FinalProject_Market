using System;
using AppCore;
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

        public async Task<List<Offer>> GetAuctionOffers(int auctionId, CancellationToken cancellationToken)
        {
            return await _offerRepository.GetAuctionOffers(auctionId, cancellationToken);

        }
    }
}

