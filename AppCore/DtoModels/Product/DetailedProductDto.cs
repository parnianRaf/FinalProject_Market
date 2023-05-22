using System;
namespace AppCore.DtoModels.Product
{
	public class DetailedProductDto
	{
        public int Id { get; set; }

        public string ProductName { get; set; }

        public decimal? Price { get; set; }

        public int SellerId { get; set; }

        public int CategoryId { get; set; }

        public int? PavilionId { get; set; }
    }
}

