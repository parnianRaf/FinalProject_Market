using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace AppCore;

public class Product
{
    #region Property
    public int Id { get; set; }

    public string ProductName { get; set; } 

    public decimal? Price { get; set; }

    public int UserId { get; set; }

    public int CategoryId { get; set; }

    public int? PavilionId { get; set; }

    public int? AuctionId { get; set; }

    public int? DirectOrderId { get; set; }

    public string? filePathSource { get; set; }

    public List<IFormFile>? ImageFiles { get; set; }

    public bool IsActive { get; set; }

    public bool IsAcceptedByAdmin { get; set; }

    public DateTime? AcceptedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedBy { get; set; }
    #endregion

    #region Navigation Property
    public virtual Auction? Auction { get; set; }

    public virtual Category Category { get; set; }

    public virtual User User { get; set; }

    public virtual DirectOrder? DirectOrder { get; set; }
    #endregion
}
