using System;
using AppCore.DtoModels.Product;

namespace AppCore.DtoModels.DirectOrder
{
	public class DetailedDirctOrderDto
    {
        public int Id { get; set; }

        public bool IsPaid { get; set; }

        public decimal TotalPrice { get; set; }

        public string SellerName { get; set; }

        public string CustomerName { get; set; }

        public string? CommentByCostumer { get; set; }

        public bool IsCommentAcceptedByAdmin { get; set; }

        public bool IsCommentDeleted { get; set; }

        public virtual List<DetailedProductDto> ProductDtos { get; set; }

    }
}

