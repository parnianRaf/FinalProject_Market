using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProject_Market.Models.ViewModels
{
    public class AddProductViewModel
    {
        [Display(Name = "نام محصول")]
        [Required]
        public string ProductName { get; set; }

        public decimal? Price { get; set; }

        public List<IFormFile>? fileImages { get; set; }
    }
}

