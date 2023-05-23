using System;
using AppCore.DtoModels.Offer;
using AppCore.DtoModels.Product;

namespace AppCore.DtoModels.Auction
{
	public class AddAuctionDto
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int SellerId { get; set; }

        public virtual List<DetailedOfferDto> OffersDto { get; set; }

        public virtual List<DetailedProductDto> ProductDtos { get; set; }
    }
}

