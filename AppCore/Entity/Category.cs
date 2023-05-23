using System;
using System.Collections.Generic;

namespace AppCore;

public  class Category
{
    #region ctor
    public Category()
    {
        Products = new List<Product>();
    }
    #endregion

    #region Property
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public DateTime CreateAt { get; set; }

    public int CreateBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public bool IsDeleted { get; set; }

    public int? DeleteBy { get; set; }

    public DateTime? DeleteAt { get; set; }
    #endregion

    #region Navigation Property
    public virtual List<Product> Products { get; set; }
    #endregion
}
