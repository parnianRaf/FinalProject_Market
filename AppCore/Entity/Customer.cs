using System;
using System.Collections.Generic;
using AppCore.Enum;

namespace AppCore;

public class Customer
{
    #region ctor
    public Customer()
    {
        CustomerAddresses = new List<CustomerAddress>();
        Offers = new List<Offer>();
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

    public DateTime CreateAt { get; set; }

    public int CreteBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeleteAt { get; set; }

    public int? DeleteBy { get; set; }
    #endregion

    #region Navigation Property
    public virtual List<CustomerAddress> CustomerAddresses { get; set; } 

    public virtual List<Offer> Offers { get; set; } 

    public virtual Wallet? Wallet { get; set; }
    #endregion
}
