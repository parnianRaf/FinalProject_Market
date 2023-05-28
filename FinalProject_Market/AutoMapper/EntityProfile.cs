using System;
using AppCore;
using AppCore.DtoModels;
using AppCore.DtoModels.Admin;
using AppCore.DtoModels.Customer;
using AppCore.DtoModels.Product;
using AutoMapper;
using FinalProject_Market.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Repositories.AutoMapper
{
	public class EntityProfile:Profile
	{
		public EntityProfile()
		{
			CreateMap<LogInViewModel, LogInAdminDto>();
			CreateMap<DetailCustomerDto, GetCustomersViewModel> ();

        }

    }
}

