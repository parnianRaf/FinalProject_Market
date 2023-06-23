using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalProject_Market.Models.ViewModels
{
	public class LogInViewModel
	{
		[Display(Name = "یوزرنیم")]
		public string UserName { get; set; }

		[Display(Name = "رمز عبور")]
		public string Password { get; set; }


		[Display(Name = "مرا به خاطر بسپار")]
		public bool IsRememberMe { get; set; }
	}
}

