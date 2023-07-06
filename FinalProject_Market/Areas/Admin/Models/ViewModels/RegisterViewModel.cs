using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FinalProject_Market.Areas.Admin.Models.ViewModels
{
	public class RegisterViewModel
	{
        public int Id { get; set; }
        [Required(ErrorMessage ="این فیلد نمی تواند خالی باشد")]
        [Display(Name ="یوزرنیم")]
		public string UserName { get; set; }
        [Required(ErrorMessage = "این فیلد نمی تواند خالی باشد")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
        [Required(ErrorMessage = "این فیلد نمی تواند خالی باشد")]
        [DataType(DataType.Password)]
        [Display(Name = "پسوورد")]
        public string Password { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "این فیلد نمی تواند خالی باشد")]
        [Display(Name = "شماره همراه")]
        public string PhoneNumber { get; set; }
	}
}

