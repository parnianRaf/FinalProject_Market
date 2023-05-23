using System;
using AppCore.DtoModels.Customer;
using AppCore.DtoModels.Pavilion;
using AppCore.DtoModels.Product;
using AppCore.Enum;

namespace AppCore.DtoModels.Seller
{
	public class EditSellerDto
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public string? NationalityCode { get; set; }

        public virtual List<DetailedProductDto> ProductDtos { get; set; }

        public virtual List<DetailedPavilionDto> PavilionDtos { get; set; }

    }
}

