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
            CreateMap<Product, DetailedProductDto>()
                .ReverseMap();

            CreateMap<Pavilion, PavilionDtoModel>();
            #endregion

            #region Auction
            CreateMap<AddAuctionDto, Auction>()
                .ForMember(dst => dst.Products, opt =>
                opt.MapFrom(src => src.ProductDtos))
                .ForMember(dst => dst.Offers, opt =>
                opt.MapFrom(src => src.OffersDto));

            CreateMap<Auction, EditAuctionDto>()
                 .ForMember(dst => dst.ProductDtos, opt =>
                opt.MapFrom(src => src.Products))
                .ForMember(dst => dst.OffersDto, opt =>
                opt.MapFrom(src => src.Offers));

            CreateMap<Auction, DetailedAuctionDto>()
                 .ForMember(dst => dst.ProductDtos, opt =>
                opt.MapFrom(src => src.Products))
                .ForMember(dst => dst.OffersDto, opt =>
                opt.MapFrom(src => src.Offers)); 
            #endregion

            #region Offer
            CreateMap<AddOfferDto, Offer>();
            CreateMap<Offer, EditOfferDto>();
            CreateMap<Offer, DetailedOfferDto>()
                .ReverseMap();
            #endregion

            #region DirectOrder
            CreateMap<AddDirectDto, DirectOrder>()
                .ForMember(s => s.Products, opt =>
                opt.MapFrom(src => src.ProductDtos));
            CreateMap<DirectOrder, EditDirectOrderDto>()
                .ForMember(dst => dst.ProductDtos, opt =>
                opt.MapFrom(src => src.Products));
            CreateMap<DirectOrder, DetailedPaidDirectOrderDto>()
                   .ForMember(dst => dst.ProductDtos, opt =>
                opt.MapFrom(src => src.Products));
            CreateMap<DirectOrder, DetailedDirctOrderDto>()
                .ForMember(dst => dst.ProductDtos, opt =>
             opt.MapFrom(src => src.Products));
            #endregion

            #region Customer
            CreateMap<AddCustomerDto, Customer>();
               
            CreateMap<IdentityUser<int>, Customer>()
				.ForMember(dst=>dst.UserId,opt=>opt.MapFrom(src=>src.Id))
                .ForMember(dst => dst.CreteBy, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.CreateAt, opt => opt.MapFrom(src => DateTime.Now));
			CreateMap<AddCustomerDto, IdentityUser<int>>();
            CreateMap<EditCustomerDto, IdentityUser<int>>();
            CreateMap<EditCustomerDto, Customer>()
                //.ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dst=>dst.ModifiedAt,opt=>opt.MapFrom(src=>DateTime.Now));
			CreateMap<Customer, DetailCustomerDto>()
                  .ForMember(dst => dst.CustomerAddressDtos, opt =>
                opt.MapFrom(src => src.CustomerAddresses))
                .ForMember(dst => dst.DirectOrderDtos, opt =>
                opt.MapFrom(src => src.DirectOrders));
            #endregion
        }

    }
}

