﻿using System;
using AppCore.DtoModels.Auction;
using AppCore.DtoModels.Customer;
using AppCore.DtoModels.DirectOrder;
using AppCore.DtoModels.Product;

namespace AppCore.DtoModels.Customer
{
	public class EditCustomerDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string NationalityCode { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsActive { get; set; }

        public DateTime? ActivatedAt { get; set; }

        public virtual Wallet? Wallet { get; set; }

        public virtual List<DetailedDirctOrderDto>? DirectOrderDtos { get; set; }

        public virtual List<DetailedCustomerAdddressDto>? CustomerAddressDtos { get; set; }

        public virtual List<DetailedAuctionDto>? AuctionDtos { get; set; }

    }
}

