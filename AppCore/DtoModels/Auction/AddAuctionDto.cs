using System;
namespace AppCore.DtoModels.Product
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

