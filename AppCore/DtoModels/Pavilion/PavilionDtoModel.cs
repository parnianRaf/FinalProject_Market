﻿using System;
using AppCore.DtoModels.Product;

namespace AppCore.DtoModels
{
	public class PavilionDtoModel
	{
        public int Id { get; set; }

        public string? Title { get; set; }

        public string SellerName { get; set; }

        public string CreatedAt { get; set; }

        public bool IsAccepted { get; set; }

        public string AcceptedAt { get; set; }

        public bool IsDeleted { get; set; }

        public string? DeletedAt { get; set; }

        public string ImageFile { get; set; }

        public List<DetailedProductDto> ProductDtos { get; set; }
    }
}

