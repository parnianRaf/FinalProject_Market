using System;
using AppCore.DtoModels.Product;

namespace AppCore.DtoModels.DirectOrder
{
	public class DirectOrderCartDto
	{
		public int Id { get; set; }

		public string CustomerFullName { get; set; }

		public string? SellerName { get; set; }

		public DateTime FactorDate { get; set; }

		public DateTime FactorExpireDate { get; set; }

		public decimal TotalPrice { get; set; }

		public List<DetailedProductDto>? ProductDtos { get; set; }

	}
}

