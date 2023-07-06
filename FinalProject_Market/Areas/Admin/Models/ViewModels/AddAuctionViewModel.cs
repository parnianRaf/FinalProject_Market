using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AppCore.DtoModels.Product;
using Foolproof;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject_Market.Models.ViewModels
{
    public class AddAuctionViewModel:IValidatableObject
    {
        [Required(ErrorMessage = "قیمت اولیه نمیتواند خالی باشد.")]
        [Display(Name = "قیمت اولیه")]
        [RegularExpression(@"^(0|-?\d{0,18}(\.\d{0,2})?)$",ErrorMessage ="قیمت وارد شده در محدوده نیست")]
        public decimal OfferSubmitWithPrice { get; set; }
        [Required]
        [Display(Name ="زمان شروع مزایده")]
        [Remote("ValidateDateEqualOrGreater", "OrderManagemnet", areaName:"Seller", ErrorMessage= "شروع مزایده باید بعد از تاریخ الان باشه")]
        public DateTime StartTime { get; set; }
        [Required]
        [Display(Name = "زمان پایان مزایده")]
        public DateTime EndTime { get; set; }
        [Required(ErrorMessage ="حتما باید ۱ کالا انتخاب شده باشد.")]
        [Display(Name = "کالاهای مدنظر خود را انتخاب کنید.")]
        public virtual List<int> ProductDtoIds { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
            if (StartTime > EndTime)
            {
                yield return new ValidationResult(
                     errorMessage: "زمان پایان کار باید بعد از زمان شروع کار باشد.",
                     memberNames: new[] { "EndTime" }
                    );
            }
        }


    }
}

