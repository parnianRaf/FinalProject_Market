using System;
using AppCore.DtoModels.Customer;
using AppCore.DtoModels.DirectOrder;
using AppCore.DtoModels.Product;
using Microsoft.AspNetCore.Http;

namespace AppCore.DtoModels.Seller
{
	public class FullDetailSellerDto
	{
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string NationalityCode { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ActivatedAt { get; set; }

        public bool? IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public string? FilePathSource { get; set; }

        public IFormFile? UserFile { get; set; }

        public DateTime? DeletedAt { get; set; }

        public string? DeleteComment { get; set; }

        public virtual SellerAddress? SellerAddress { get; set; }

    }
}

