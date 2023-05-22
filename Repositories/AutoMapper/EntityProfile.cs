using System;
using AppCore;
using AppCore.DtoModels;
using AppCore.DtoModels.Product;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Repositories.AutoMapper
{
	public class EntityProfile:Profile
	{
		public EntityProfile()
		{
            #region Product
            CreateMap<AddProductDto, Product>();
            CreateMap<Product,EditProductDto > ();
            CreateMap<Product, DetailedProductDto>();
            CreateMap<Product, List<DetailedProductDto>>();

            CreateMap<Pavilion, PavilionDtoModel>();
            #endregion


            #region Auction
            CreateMap<AddAuctionDto, Auction>();
            CreateMap<Auction, EditAuctionDto>();
            CreateMap<Auction, DetailedAuctionDto>();
            #endregion


            CreateMap<AddCustomerDto, Customer>();


            CreateMap<IdentityUser<int>, Customer>()
				.ForMember(dst=>dst.UserId,opt=>opt.MapFrom(src=>src.Id))
				.ForMember(dst=>dst.CreteBy,opt=>opt.MapFrom(src=>src.Id))
                .ForMember(dst => dst.CreateAt, opt => opt.MapFrom(src => DateTime.Now));

			CreateMap<AddCustomerDto, IdentityUser<int>>();
            CreateMap<EditCustomerDto, IdentityUser<int>>();
            CreateMap<EditCustomerDto, Customer>()
                .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dst=>dst.ModifiedAt,opt=>opt.MapFrom(src=>DateTime.Now));

			CreateMap<Customer, DetailCustomerDto>();


        }

    }
}

