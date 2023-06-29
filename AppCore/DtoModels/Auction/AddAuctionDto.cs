using System;
using AppCore.DtoModels.Offer;
using AppCore.DtoModels.Product;

namespace AppCore.DtoModels.Auction
{
	public class AddAuctionDto
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public virtual List<int> ProductDtoIds { get; set; }

        public virtual List<DetailedProductDto> Products { get; set; }
    }
}

