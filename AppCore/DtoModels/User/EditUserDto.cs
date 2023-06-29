using System;
using AppCore.DtoModels.Product;

namespace AppCore.DtoModels.User
{
	public class EditUserDto
	{
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string? NationalityCode { get; set; }

        public virtual SellerAddress? SellerAddress { get; set; }

        public virtual List<CustomerAddress>? CustomerAddresses { get; set; }
    }
}

