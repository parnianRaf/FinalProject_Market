﻿using System;
namespace AppCore.DtoModels.Seller
{
	public class LogInSellerDto
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public bool IsRememberMe { get; set; }
	}
}

