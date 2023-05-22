using System;
using System.Collections.Generic;

namespace AppCore;

public class CustomerAddress
{
    #region Property
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public string? AddressTitle { get; set; }

    public string? FullAddress { get; set; }

    public bool IsMainAddress { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreateBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeleteAt { get; set; }

    public int? DeleteBy { get; set; }
    #endregion

    #region Navigation Property
    public virtual Customer Customer { get; set; } = null!;
    #endregion
}
