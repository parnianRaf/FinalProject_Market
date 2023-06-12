using System;
using Microsoft.AspNetCore.Http;

namespace AppCore.DtoModels.Product
{
	public class AddProductDto
	{

        public string ProductName { get; set; }

        public decimal? Price { get; set; }

        public IFormFile? fileImage { get; set; }

    }
}

