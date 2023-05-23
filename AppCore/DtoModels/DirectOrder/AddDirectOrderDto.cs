using System;
namespace AppCore.DtoModels.Product
{
	public class AddAuctionDto
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int SellerId { get; set; }
    }
}

