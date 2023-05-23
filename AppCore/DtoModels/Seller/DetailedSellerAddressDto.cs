using System;
namespace AppCore.DtoModels.Seller
{
	public class DetailedSellerAddressDto
    {
        public int SellerId { get; set; }

        public string? AddressTitle { get; set; }

        public string? FullAddress { get; set; }
    }
}

