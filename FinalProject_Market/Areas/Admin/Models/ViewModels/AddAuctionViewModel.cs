using System;
using System.ComponentModel.DataAnnotations;
using AppCore.DtoModels.Product;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject_Market.Models.ViewModels
{
    public class AddAuctionViewModel
    {
        [Required(ErrorMessage = "قیمت اولیه نمیتواند خالی باشد.")]
        [Display(Name = "قیمت اولیه")]
        public decimal OfferSubmitWithPrice { get; set; }
        [Required]
        [Display(Name ="زمان شروع مزایده")]
        [Remote("ValidateDateEqualOrGreater", "OrderManagemnet", areaName: "Seller", ErrorMessage = "شروع مزایده باید بعد از تاریخ الان باشه")]
        public DateTime StartTime { get; set; }
        [Required]
        [Display(Name = "زمان پایان مزایده")]
        public DateTime EndTime { get; set; }
        [Required(ErrorMessage ="حتما باید ۱ کالا انتخاب شده باشد.")]
        [Display(Name = "کالاهای مدنظر خود را انتخاب کنید.")]
        public virtual List<int> ProductDtoIds { get; set; }


    }
}

