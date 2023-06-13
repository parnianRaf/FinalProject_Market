using System;
namespace AppCore.DtoModels.Seller
{
	public class SellerOverViewDto
	{
        public string FullName { get; set; }
        public bool HasMedal { get; set; }
        public int CompletedOrderNumber { get; set; }
        public int CompletedAuctionNumber { get; set; }

    }
}

