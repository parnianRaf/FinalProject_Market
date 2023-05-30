using System;
using System.Collections.Generic;

namespace AppCore;

public class Auction
{
    #region ctor
    public Auction()
    {
        Offers = new List<Offer>();
        Products = new List<Product>();
    }
    #endregion

    #region Property
    public int Id { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public int? OfferSubmitByCustomerId { get; set; }

    public decimal? OfferSubmitWithPrice { get; set; }

    public int? AcceptedCustomerId { get; set; }

    public decimal? FinalPrice { get; set; }

    public int SellerId { get; set; }

    public bool IsCommentAcceptedByAdmin { get; set; }

    public DateTime? CommentAcceptedAt { get; set; }

    public bool IsCommentDeleted { get; set; }

    public DateTime? CommentDeletedAt { get; set; }

    public string? FinalCommentByCostumer { get; set; }

    public bool IsFinished { get; set; }

    public DateTime CreateAt { get; set; }

    public int CreateBy { get; set; }

    public DateTime? ModeifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public bool IsDeleted { get; set; }

    public int? DeleteBy { get; set; }

    public DateTime? DeleteAt { get; set; }
    #endregion

    #region Navigation Property
    public virtual List<Offer> Offers { get; set; }

    public virtual List<Product> Products { get; set; } 
    #endregion
}
