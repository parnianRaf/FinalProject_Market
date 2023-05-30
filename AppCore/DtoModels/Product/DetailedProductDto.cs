using System;
namespace AppCore.DtoModels.Product
{
	public class DetailedProductDto
	{
        public int Id { get; set; }

        public string? ProductName { get; set; }

        public decimal? Price { get; set; }

        public string? SellerFullName { get; set; }

        public string? CategoryName { get; set; }

        public string? PavilionName { get; set; }

        public string? filePathSource { get; set; }
    }
}

