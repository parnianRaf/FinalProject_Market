using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AppCore.AppServices.Admin.Query;
using AppCore.AppServices.Admin_.Command;
using AppCore.AppServices.Admin_.Query;
using AppCore.DtoModels;
using AppCore.DtoModels.Admin;
using AppCore.DtoModels.Auction;
using AppCore.DtoModels.Customer;
using AppCore.DtoModels.DirectOrder;
using AppCore.DtoModels.Product;
using AppCore.DtoModels.Seller;
using AppCore.DtoModels.User;
using AppService.Admin;
using AppService.Admin.Commands;
using AppService.Admin.Queries;
using AppService.Admin_.Command;
using AutoMapper;
using FinalProject_Market.Models;
using FinalProject_Market.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject_Market.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        #region field
        private readonly IAccountAppServices _account;
        private readonly IMapper _mapper;
        #endregion

        #region ctor
        public AccountController(IAccountAppServices account,
            IMapper mapper)
        {
            _account = account;
            _mapper = mapper;
        }
        #endregion

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult LogIn(int id)
        {
            switch (id)
            {
                case 1:
                    return PartialView();
                case 2:
                    return PartialView();
                case 3:
                    return PartialView("LogIn");
            }
            return RedirectToAction("Index");
            
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(int id,LogInViewModel viewModel, CancellationToken cancellation)
        {
            LogInUser userDto = _mapper.Map<LogInUser>(viewModel);
            var result=await _account.LogIn(id, userDto, cancellation);
            switch (result)
            {
                case 1:
     
                    break;
                case 2:
         
                    break;
                case 3:
                    return PartialView("AdminPannel");
            }
            ModelState.AddModelError(string.Empty, "یوزر یا پسورد اشتباه بوده...");
            return PartialView(viewModel);

        }

        public async Task<IActionResult> GetCustomerList(CancellationToken cancellation)
        {
            List<DetailCustomerDto> customerDtos = await _account.GetAllCustomers<DetailCustomerDto>(cancellation);
            List<GetCustomersViewModel> customersViewModels = _mapper.Map<List<GetCustomersViewModel>>(customerDtos);
            return View(customersViewModels);
        }

        public async Task<IActionResult> GetSellerList(CancellationToken cancellation)
        {
            List<DetailSellerDto> sellerDtos = await _account.GetAllSellers<DetailSellerDto>(cancellation);
            List<GetSellersViewModel> sellerViewModels = _mapper.Map<List<GetSellersViewModel>>(sellerDtos);
            return View(sellerViewModels);
        }


        public async Task<IActionResult> CustomerProfile(int id, CancellationToken cancellation)
        {
            FullDetailCustomerViewModel viewModel = _mapper.Map<FullDetailCustomerViewModel>(await _account.GetUser<FullDetailCustomerDto>(id,cancellation));
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CustomerProfile(FullDetailCustomerViewModel viewModel, CancellationToken cancellation)
        {
            var customer = _mapper.Map<EditUserDto>(viewModel);
            var result = await _account.UpdateUser(customer, cancellation);
            if (result)
            {
                return RedirectToAction("CustomerProfile", new { viewModel.Id });
            }
            return View(viewModel);
        }



        //public async Task<IActionResult> SellerProfile(int id, CancellationToken cancellation)
        //{

        //    FullDetailSellerViewModel viewModel = _mapper.Map<FullDetailSellerViewModel>(await _account.GetUser<EditUserDto>(id,cancellation);
        //    List<DetailedProductDto> productDtos await _sellerProducts.Execute(id, cancellation);
        //    List<PavilionDtoModel> pavilionDtos = await _sellerPavilions.Execute(id, cancellation);

        //    ViewBag.productDtos = productDtos;
        //    ViewBag.pavilionDtos = pavilionDtos;
        //    return View(viewModel);
        //}

        //[HttpPost]
        //public async Task<IActionResult> SellerProfile(FullDetailSellerViewModel viewModel, CancellationToken cancellation)
        //{
        //    var sellerDto = _mapper.Map<EditSellerDto>(viewModel);
        //    var result = await _editSeller.Execute(sellerDto, cancellation);
        //    if (result)
        //    {
        //        return RedirectToAction("SellerProfile", new {viewModel.Id});
        //    }
        //    return View(viewModel);
        //}


        //public async Task<IActionResult> GetOrdersList(CancellationToken cancellation)
        //{
        //    List<DetailedDirctOrderDto> dirctOrderDtos = await _paidOrders.Execute(cancellation);
        //    List<DetailedAuctionDto> auctionDtos = await _auctions.Execute(cancellation);
        //    ViewBag.directOrderDtos = dirctOrderDtos; 
        //    return View(auctionDtos);
        //}

        public async Task<IActionResult> DeleteUser(int id, CancellationToken cancellation)
        {
            var DeactiveResult = await _account.DeleteUser(id, cancellation);
            if (DeactiveResult)
            {
                return RedirectToAction("CustomerProfile", new { id });
            }
            return RedirectToAction("DeleteUser", new { id });
        }

        public async Task<IActionResult> ActiveUser(int id, CancellationToken cancellation)
        {
            var ActiveResult = await _account.ActiveUser(id, cancellation);
            if (ActiveResult)
            {
                return RedirectToAction("CustomerProfile", new { id });
            }
            return RedirectToAction("ActiveUser", new { id });
        }



        //public async Task<IActionResult> SeedData()
        //{

        //    var test1 = await _account.SeedAdminData();
        //    if (!test1)
        //    {
        //        return RedirectToAction("Index", "Account");
        //    }
        //    return RedirectToAction("Index", "Account");

        //}
    }
}

