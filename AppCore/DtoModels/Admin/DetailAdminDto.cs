﻿using System;
using AppCore.DtoModels.Customer;
using AppCore.DtoModels.Product;

namespace AppCore.DtoModels.Admin
{
	public class DetailAdminDto
	{
        public int Id { get; set; }

        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string NationalityCode { get; set; }
    }
}

