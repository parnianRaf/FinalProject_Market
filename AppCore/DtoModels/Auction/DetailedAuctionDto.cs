using System;
using AppCore.DtoModels.Offer;
using AppCore.DtoModels.Product;

namespace AppCore.DtoModels.Auction
{
	public class DetailedAuctionDto
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string? AcceptedCustomerName { get; set; }

        public decimal? FinalPrice { get; set; }

        public string SellerName { get; set; }

        public bool IsCommentAcceptedByAdmin { get; set; }

        public string ComissionPaidByauction { get; set; }

        public DateTime? CommentAcceptedAt { get; set; }

        public bool IsCommentDeleted { get; set; }

        public DateTime? CommentDeletedAt { get; set; }

        public string? FinalCommentByCostumer { get; set; }

        public bool IsFinished { get; set; }

        public virtual List<DetailedProductDto> ProductDtos { get; set; }

    }
}

