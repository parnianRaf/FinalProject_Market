﻿using System;
namespace AppCore.DtoModels.Customer
{
	public class LogInCustomerDto
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public bool IsRememberMe { get; set; }
	}
}

