using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProject_Market.Models.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } 

        public string ImageFile { get; set; }
    }
}

