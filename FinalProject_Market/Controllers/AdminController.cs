﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.AppServices.Admin.Command;
using AppCore.AppServices.Admin.Query;
using AppCore.AppServices.Admin_.Command;
using AppCore.DtoModels.Admin;
using AppCore.DtoModels.Customer;
using AppCore.DtoModels.Seller;
using AppService.Admin;
using AppService.Admin.Commands;
using AutoMapper;
using FinalProject_Market.Models;
using FinalProject_Market.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject_Market.Controllers
{
    public class AdminController : Controller
    {
        #region field
        private readonly ISeedData _data;
        private readonly IMapper _mapper;
        private readonly ILogIn _logIn;
        private readonly IGetCustomers _customers;
        private readonly IGetSellers _sellers;
        private readonly IGetSeller _seller;
        private readonly IGetCustomer _customer;
        private readonly IEditCustomer _editCustomer;
        private readonly IEditSeller _editSeller;
        private readonly IDeactiveUser _deactiveUser;
      
        #endregion

        #region ctor
        public AdminController(ISeedData data
            ,ILogIn logIn, IGetCustomer customer, IDeactiveUser deactiveUser,
             IMapper mapper, IGetCustomers customers, IEditSeller editSeller
            , IEditCustomer editCustomer, IGetSellers sellers
            , IGetSeller seller)
        {
            _data = data;
            _mapper = mapper;
            _logIn = logIn;
            _customers = customers;
            _customer = customer;
            _editCustomer = editCustomer;
            _sellers = sellers;
            _editSeller = editSeller;
            _seller = seller;
            _deactiveUser = deactiveUser;
        }
        #endregion

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LogIn()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel viewModel,CancellationToken cancellation)
        {
            LogInAdminDto adminDto = _mapper.Map<LogInAdminDto>(viewModel);


                var logInResult =await _logIn.Execute(adminDto, cancellation);
                if(logInResult.Succeeded)
                {
                    return PartialView("AdminPannel");
                }
                ModelState.AddModelError(string.Empty, "یوزر یا پسورد اشتباه بوده...");
            
            return PartialView(viewModel);

        }

       // inja duplicate darimmmmmmmmmmmmmm !!!!!!!!!!!!!!!!!

        public async Task<IActionResult> CustomerProfile(int id,CancellationToken cancellation)
        {
            FullDetailCustomerViewModel viewModel= _mapper.Map<FullDetailCustomerViewModel>(await _customer.Execute(id, cancellation));
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CustomerProfile (FullDetailCustomerViewModel viewModel,CancellationToken cancellation)
        {
            var customer = _mapper.Map<EditCustomerDto>(viewModel);
            var result = await _editCustomer.Execute(customer, cancellation);
            if (result)
            {
                return RedirectToAction("CustomerProfile", new {viewModel.Id});
            }
            return View(viewModel);
        }

        public async Task<IActionResult> SellerProfile(int id, CancellationToken cancellation)
        {
            FullDetailSellerViewModel viewModel = _mapper.Map<FullDetailSellerViewModel>(await _seller.Execute(id, cancellation));
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SellerProfile(FullDetailSellerViewModel viewModel, CancellationToken cancellation)
        {
            var sellerDto = _mapper.Map<EditSellerDto>(viewModel);
            var result = await _editSeller.Execute(sellerDto, cancellation);
            if (result)
            {
                return RedirectToAction("CustomerProfile", new {viewModel.Id});
            }
            return View(viewModel);
        }

        public async Task<IActionResult> GetCustomerList(CancellationToken cancellation)
        {
            List<DetailCustomerDto> customerDtos =await  _customers.Execute(cancellation);
            List<GetCustomersViewModel> customersViewModels = _mapper.Map<List<GetCustomersViewModel>>(customerDtos);
            return PartialView(customersViewModels);
        }

        public async Task<IActionResult> GetSellerList(CancellationToken cancellation)
        {
            List<DetailSellerDto> sellerDtos = await _sellers.Execute(cancellation);
            List<GetSellersViewModel> sellerViewModels = _mapper.Map<List<GetSellersViewModel>>(sellerDtos);
            return PartialView(sellerViewModels);
        }

        public async Task<IActionResult> DeleteUser(int id, CancellationToken cancellation)
        {
            var DeactiveResult= await _deactiveUser.Execute(id, cancellation);
            if(DeactiveResult)
            {
                return RedirectToAction("CustomerProfile", new { id });
            }
            return RedirectToAction("DeActive",new { id});
        }
  
 

        //public async Task<IActionResult> SeedData()
        //{

        //    var test1 = await _data.Execute();
        //    if (!test1)
        //    {
        //        return RedirectToAction("Privacy", "Home");
        //    }
        //    return RedirectToAction("Index", "Home");

        //}
    }
}

