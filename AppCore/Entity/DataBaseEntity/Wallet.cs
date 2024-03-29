﻿using System;
using System.Collections.Generic;

namespace AppCore;

public class Wallet
{
    #region Property
    public int UserId { get; set; }

    public decimal Credit { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public bool IsDeleted { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }
    #endregion

    #region Navigation Property
    public virtual User User { get; set; } = null!;
    #endregion
}
