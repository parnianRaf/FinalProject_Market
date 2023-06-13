using System;
using AppCore;
using AppCore.DtoModels;
using AppCore.DtoModels.Admin;
using AppCore.DtoModels.Auction;
using AppCore.DtoModels.Category;
using AppCore.DtoModels.Customer;
using AppCore.DtoModels.Product;
using AppCore.DtoModels.Seller;
using AppCore.DtoModels.User;
using AutoMapper;
using FinalProject_Market.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Repositories.AutoMapper
{
	public class EntityProfile:Profile
	{
		public EntityProfile()
		{

            CreateMap<FullDetailCustomerViewModel, EditUserDto>()
                .ReverseMap();

            CreateMap<EditUserDto, FullDetailSellerViewModel>()
                .ReverseMap();

            CreateMap<LogInViewModel, LogInUser>();

            CreateMap<DetailCustomerDto, GetCustomersViewModel>();
			CreateMap<FullDetailCustomerDto, FullDetailCustomerViewModel > ();
            CreateMap<DetailedCustomerAdddressDto, DetailedCustomerAddressViewModel>();
            CreateMap<FullDetailCustomerDto, FullDetailCustomerViewModel>();
            CreateMap<FullDetailCustomerViewModel, EditCustomerDto > ();

            CreateMap<DetailSellerDto, GetSellersViewModel>();
            CreateMap<FullDetailSellerDto, FullDetailSellerViewModel>();
            CreateMap<FullDetailSellerViewModel, EditSellerDto>();


            CreateMap<CategoryDtoModel, CategoryViewModel>().ReverseMap();

            CreateMap<AddAuctionViewModel, AddAuctionDto>().ReverseMap();

            //CreateMap<FullDetailCustomerDto, FullDetailCustomerViewModel>();
            //CreateMap<DetailedCustomerAdddressDto, DetailedCustomerAddressViewModel>();
            //CreateMap<FullDetailCustomerDto, FullDetailCustomerViewModel>();
            //CreateMap<FullDetailCustomerViewModel, EditCustomerDto>();

        }

    }
}

