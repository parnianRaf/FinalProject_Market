using System;
using System.Collections.Generic;

namespace AppCore;

public class DirectOrder
{
    #region ctor
    public DirectOrder()
    {
        Products = new List<Product>();
    }
    #endregion

    #region Property
    public int Id { get; set; }

    public bool IsPaid { get; set; }

    public DateTime? PaidAt { get; set; }

    public decimal TotalPrice { get; set; }

    public int UserId { get; set; }

    public int SellerId { get; set; }

    public string? CommentByCostumer { get; set; }

    public bool IsCommentAcceptedByAdmin { get; set; }

    public bool IsCommentDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public bool IsDeleted { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }
    #endregion

    #region Navigation Property
    public virtual List<Product> Products { get; set; }
    public virtual User User { get; set; }
    #endregion
}
