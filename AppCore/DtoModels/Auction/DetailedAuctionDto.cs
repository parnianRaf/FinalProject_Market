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

        public int? OfferSubmitByCustomerId { get; set; }

        public decimal? OfferSubmitWithPrice { get; set; }

        public int? AcceptedCustomerId { get; set; }

        public decimal? FinalPrice { get; set; }

        public int SellerId { get; set; }

        public string? CommentByCostumer { get; set; }

        public bool IsCommentAcceptedByAdmin { get; set; }

        public bool IsCommentDeleted { get; set; }

        public string? FinalCommentByCostumer { get; set; }

        public bool IsFinished { get; set; }

        public virtual List<DetailedOfferDto> OffersDto { get; set; }

        public virtual List<DetailedProductDto> ProductDtos { get; set; }

    }
}

