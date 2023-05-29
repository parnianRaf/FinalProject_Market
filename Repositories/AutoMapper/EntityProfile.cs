using System;
using AppCore;
using AppCore.DtoModels;
using AppCore.DtoModels.Admin;
using AppCore.DtoModels.Auction;
using AppCore.DtoModels.Category;
using AppCore.DtoModels.Customer;
using AppCore.DtoModels.DirectOrder;
using AppCore.DtoModels.Offer;
using AppCore.DtoModels.Product;
using AppCore.DtoModels.Seller;
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

            #region Category
            CreateMap<Category, CategoryDtoModel>().ReverseMap();
            #endregion

            #region Pavilion
            CreateMap<Pavilion, PavilionDtoModel>().ReverseMap();
            #endregion

            #region Customer Address
            CreateMap<CustomerAddress, DetailedCustomerAdddressDto>().ReverseMap();
            #endregion

            #region Customer
            CreateMap<AddCustomerDto, User>()
               //.ForMember(dst => dst.CreatedBy, opt =>
               //opt.MapFrom(src => src.Id))
                 .ForMember(dst => dst.CreatedAt, opt =>
                 opt.MapFrom(src => DateTime.Now));

            CreateMap<AddAdminDto, User>()
                //.ForMember(dst => dst.CreatedBy, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.CreatedAt, opt =>
                opt.MapFrom(src => DateTime.Now));

            CreateMap<EditCustomerDto, User>()
              //.ForMember(dst => dst.ModifiedBy, opt =>
              //opt.MapFrom(src => src.UserId))
                .ForMember(dst => dst.ModifiedAt, opt =>
                opt.MapFrom(src => DateTime.Now))
                .ReverseMap();

            CreateMap<User, DetailCustomerDto>()
                .ForMember(dst=>dst.FullName,opt=>
                opt.MapFrom(src=>$"{src.FirstName} {src.LastName}"));

            CreateMap<User, FullDetailCustomerDto>()
                .ForMember(dst => dst.CustomerAddressDtos,opt=>
                opt.MapFrom(src=>src.CustomerAddresses));
            #endregion

            #region Admin
            CreateMap<AddAdminDto, User>()
                //.ForMember(dst => dst.CreatedBy, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.CreatedAt, opt => opt.MapFrom(src => DateTime.Now)); 
            CreateMap<AddAdminDto, User>()
                //.ForMember(dst => dst.CreatedBy, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.CreatedAt, opt => opt.MapFrom(src => DateTime.Now)); 
            CreateMap<EditAdminDto, User>()
                //.ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => DateTime.Now))
                .ReverseMap();



            #endregion

            #region Seller
            CreateMap<AddSelllerDto, User>()
                 //.ForMember(dst => dst.CreatedBy, opt =>
                 //opt.MapFrom(src => src.Id))
                 .ForMember(dst => dst.CreatedAt, opt =>
                 opt.MapFrom(src => DateTime.Now));

            CreateMap<EditSellerDto, User>()
                //.ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => DateTime.Now))
                .ReverseMap(); 

            CreateMap<User, DetailSellerDto>()
            .ForMember(dst => dst.FullName, opt =>
            opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<User, FullDetailCustomerDto>()
            .ForMember(dst => dst.CustomerAddressDtos, opt =>
            opt.MapFrom(src => src.CustomerAddresses));

            #endregion
        }

    }
}

