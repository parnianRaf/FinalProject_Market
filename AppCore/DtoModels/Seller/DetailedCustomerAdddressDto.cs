using System;
namespace AppCore.DtoModels.Customer
{
	public class DetailedCustomerAdddressDto
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string? AddressTitle { get; set; }

        public string? FullAddress { get; set; }

        public bool IsMainAddress { get; set; }
    }
}

