using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProject_Market.Areas.Customer.Models.ViewModels
{
	public class AddOfferViewModel
	{
        public int AuctionId { get; set; }
        [Required]
        [MaxLength(15)]
        [Display(Name = "لطفا پیشنهاد خود را مطرح کنید.")]
        public string Price { get; set; }
    }
}

