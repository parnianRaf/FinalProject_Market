using System;
namespace AppCore.DtoModels.Offer
{
	public class EditOfferDto
	{
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int AuctionId { get; set; }

        public decimal Price { get; set; }

        public DateTime SubmitAt { get; set; }
    }
}

