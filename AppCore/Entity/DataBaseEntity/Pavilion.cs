﻿using System;
using System.Collections.Generic;

namespace AppCore;

public class Pavilion
{
    #region Property
    public int Id { get; set; }

    public string? Title { get; set; }

    public int UserId { get; set; }

    public bool IsAccepted { get; set; }

    public DateTime? AcceptedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedBy { get; set; }

    public string? ImageFile { get; set; }
    #endregion

    #region Navigation Property 
    public virtual User User { get; set; } 
    #endregion
}
