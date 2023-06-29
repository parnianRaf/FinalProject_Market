using System;
using System.ComponentModel.DataAnnotations;
using AppCore.DtoModels.Product;

namespace FinalProject_Market.Models.ViewModels
{
    public class AddAuctionViewModel
    {
        [Required]
        [Display(Name ="زمان شروع مزایده")]
        public DateTime StartTime { get; set; }
        [Required]
        [Display(Name = "زمان پایان مزایده")]
        public DateTime EndTime { get; set; }
        [Required]
        [Display(Name = "کالاهای مدنظر خود را انتخاب کنید.")]
        public virtual List<int> ProductDtoIds { get; set; }

        public virtual List<DetailedProductDto> Products { get; set; }


    }
}

