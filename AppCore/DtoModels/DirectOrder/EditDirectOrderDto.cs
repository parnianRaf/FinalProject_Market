using System;
namespace AppCore.DtoModels.Product
{
	public class EditDirectOrderDto
	{
        public int Id { get; set; }

        public decimal TotalPrice { get; set; }

        public int SellerId { get; set; }

        public virtual List<DetailedProductDto> ProductDtos { get; set; }
    }
}

