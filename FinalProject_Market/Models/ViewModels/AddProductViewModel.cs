using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProject_Market.Models.ViewModels
{
	public class AddProductViewModel
	{
        [Display(Name ="نام محصول")]
        public string ProductName { get; set; }

        public decimal? Price { get; set; }

        public int CategoryId { get; set; }

        public IFormFile? fileImage { get; set; }
    }
}

