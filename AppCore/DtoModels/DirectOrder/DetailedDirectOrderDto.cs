using System;
using AppCore.DtoModels.Product;

namespace AppCore.DtoModels.DirectOrder
{
	public class DetailedDirctOrderDto
    {
        public int Id { get; set; }

        public decimal TotalPrice { get; set; }

        public int SellerId { get; set; }

        public string? CommentByCostumer { get; set; }

        public virtual List<DetailedProductDto> ProductDtos { get; set; }

    }
}

