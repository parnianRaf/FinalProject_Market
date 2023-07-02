using System;
using System.Collections.Generic;

namespace AppCore;

public class Offer
{
    #region Property
    public int Id { get; set; }

    public int UserId { get; set; }

    public int AuctionId { get; set; }

    public decimal Price { get; set; }

    public DateTime SubmitAt{ get; set; }

    public bool IsAccepted { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedBy { get; set; }
    #endregion

    #region Navigation Property
    public virtual Auction Auction { get; set; } 

    public virtual User User { get; set; }
    #endregion
}
