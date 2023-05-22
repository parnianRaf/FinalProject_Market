using System;
namespace AppCore.DtoModels.Product
{
	public class AddOfferDto
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int AuctionId { get; set; }

        public decimal Price { get; set; }

        public DateTime SubmitAt { get; set; }
    }
}

