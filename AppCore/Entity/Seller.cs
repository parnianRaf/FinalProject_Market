using System;
using System.Collections.Generic;
using AppCore.Enum;

namespace AppCore;

public class Seller
{
    #region ctor
    public Seller()
    {
        Products  = new List<Product>();
    }
    #endregion

    #region Property
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string Email { get; set; } 

    public string PhoneNumber { get; set; }

    public string UserName { get; set; } 

    public string PasswordHash { get; set; } 

    public string? NationalityCode { get; set; }

    public bool? HasMedal { get; set; }

    public DateTime? MedalAchievedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedBy { get; set; }

    #endregion

    #region Navigation Property
    public virtual Region Region { get; set; }

    public virtual List<Product> Products { get; set; } 

    public virtual SellerAddress SellerAddress { get; set; }

    public virtual List<Pavilion> Pavilions { get; set; }
    #endregion
}
