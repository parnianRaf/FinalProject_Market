using System;
using AppCore.DtoModels.Customer;
using AppCore.DtoModels.DirectOrder;
using AppCore.DtoModels.Product;

namespace AppCore.DtoModels.Customer
{
	public class DetailCustomerDto
	{
        public int Id { get; set; }

        public string FullName { get; set; }

        public string CreatedAt { get; set; }

        public string? ActivatedAt { get; set; }

        public bool? IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public string? DeletedAt { get; set; }

        public string? DeleteComment { get; set; }

    }
}

