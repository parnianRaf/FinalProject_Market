using System;
using AppCore;
using AppCore.DtoModels.Customer;
using AppCore.DtoModels.DirectOrder;

namespace FinalProject_Market.Models.ViewModels
{
	public class GetCustomersViewModel
	{
        public int Id { get; set; }

        public string FullName { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ActivatedAt { get; set; }

        public bool? IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        public string? DeleteComment { get; set; }
    }
}

