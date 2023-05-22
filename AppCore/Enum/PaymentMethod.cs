using System;
using System.ComponentModel;

namespace AppCore.Enum
{
	public enum PaymentMethod
	{
		[Description("برداشت از کیف پول")]
		برداشتازکیفپول=1,
		[Description("پرداخت اعتباری")]
		پرداختاعتباری,
		[Description("پرداخت درب منزل")]
		پرداختردبمنزل
	
	}
}

