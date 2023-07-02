using System;
using System.Collections.Generic;
using AppCore.Enum;

namespace AppCore;

public class SellerAddress
{
    #region Property
    public int UserId { get; set; }

    public string? AddressTitle { get; set; }

    public string? FullAddress { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public bool IsDeleted { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }
    #endregion

    #region Navigation Property
    //public virtual Region Region { get; set; }

    public virtual User User { get; set; } 
    #endregion
}
