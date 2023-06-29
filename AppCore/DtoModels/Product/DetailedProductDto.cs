using System;
namespace AppCore.DtoModels.Product
{
	public class DetailedProductDto
	{
        public int Id { get; set; }

        public string? ProductName { get; set; }

        public decimal? Price { get; set; }

        public string? SellerFullName { get; set; }

        public string? ActivatedAt { get; set; }

        public string CreatedAt { get; set; }

        public string? CategoryName { get; set; }

        public int? PavilionId { get; set; }

        public string? PavilionName { get; set; }

        public string? PavilionImageSource { get; set; }

        public string? filePathSource { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public string? DeletedAt { get; set; }
    }
}

