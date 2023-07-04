﻿using System;
namespace AppCore.DtoModels.User
{
	public class FullDetailUserDto
	{
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string NationalityCode { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ActivatedAt { get; set; }

        public bool? IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        public string? DeleteComment { get; set; }

        public virtual SellerAddress? SellerAddress { get; set; }

        public virtual List<CustomerAddress>? CustomerAddresses { get; set; }
    }
}
