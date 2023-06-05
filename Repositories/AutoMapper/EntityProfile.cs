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
using ExtensionMethods;
using AppCore.DtoModels.User;

namespace Repositories.AutoMapper
{
	public class EntityProfile:Profile
	{
		public EntityProfile()
		{
            #region Product
            CreateMap<AddProductDto, Product>();
            CreateMap<Product,EditProductDto > ();
            CreateMap<Product,DetailedProductDto>()
                .ForMember(dst => dst.CreatedAt, opt =>
                opt.MapFrom(src => src.CreatedAt.IranianDate2()))
                .ForMember(dst => dst.ActivatedAt, opt =>
                    opt.MapFrom(src => src.AcceptedAt.IranianDate()))
                .ForMember(dst => dst.DeletedAt, opt =>
                opt.MapFrom(src => src.DeletedAt.IranianDate()));
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

            #endregion

            #region Category
            CreateMap<Category, CategoryDtoModel>().ReverseMap();
            #endregion

            #region Pavilion
            CreateMap<Pavilion, PavilionDtoModel>()
                .ForMember(dst=>dst.SellerName,opt=>
                opt.MapFrom(src=>src.User.FullNameToString()))
                     .ForMember(dst => dst.CreatedAt, opt =>
                opt.MapFrom(src => src.CreatedAt.IranianDate2()))
                  .ForMember(dst => dst.AcceptedAt, opt =>
                opt.MapFrom(src => src.AcceptedAt.IranianDate()))
                    .ForMember(dst => dst.DeletedAt, opt =>
                opt.MapFrom(src => src.DeletedAt.IranianDate())) 
                .ReverseMap();
            #endregion

            #region  Address
            CreateMap<CustomerAddress, DetailedCustomerAdddressDto>().ReverseMap();
            CreateMap<SellerAddress, DetailedSellerAddressDto>().ReverseMap();
            #endregion

            #region User
            CreateMap<AddUserDto, User>();
            CreateMap<User, EditUserDto>().ReverseMap();
            CreateMap<User, FullDetailUserDto>();
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
                .ForMember(dst=>dst.SecurityStamp,opt=>
                opt.Ignore())
                .ReverseMap();

            CreateMap<User, DetailCustomerDto>()
                .ForMember(dst => dst.FullName, opt =>
                opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dst => dst.CreatedAt, opt =>
                opt.MapFrom(src => src.CreatedAt.IranianDate2()))
                  .ForMember(dst => dst.ActivatedAt, opt =>
                opt.MapFrom(src => src.ActivatedAt.IranianDate()))
                    .ForMember(dst => dst.DeletedAt, opt =>
                opt.MapFrom(src => src.DeletedAt.IranianDate())); 
        

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
             opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
             .ForMember(dst => dst.CreatedAt, opt =>
             opt.MapFrom(src => src.CreatedAt.IranianDate2()))
               .ForMember(dst => dst.ActivatedAt, opt =>
             opt.MapFrom(src => src.ActivatedAt.IranianDate()))
                 .ForMember(dst => dst.DeletedAt, opt =>
             opt.MapFrom(src => src.DeletedAt.IranianDate()));
       

            CreateMap<User, FullDetailSellerDto>()
            .ForMember(dst => dst.SellerAddress, opt =>
            opt.MapFrom(src => src.SellerAddress));
            #endregion
        }

    }
}

