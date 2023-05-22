using System;
using System.ComponentModel;

namespace AppCore.Enum
{
	public enum Shipping
	{
            پیک=1,
        [Description("پست پیشتاز")]
        پستپیشتاز,
        [Description("پست سفارشی")]
        پستسفارشی
    }
}

