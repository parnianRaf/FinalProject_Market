using System;
using System.Collections.Generic;

namespace AppCore;

public class Admin
{
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
    #endregion
}
