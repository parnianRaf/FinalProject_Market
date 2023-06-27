﻿using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProject_Market.Areas.Customer.Models.ViewModels
{
	public class AddCommentViewModel
	{
        [Required]
        [MaxLength(150)]
        [Display(Name ="لطفا نظر خود را با ما به اشتراک بگذارید")]
        public string CommentByCostumer { get; set; }
    }
}

