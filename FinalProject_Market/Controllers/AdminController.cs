using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.AppServices.Admin.Command;
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
using AppService.Admin;
using AppService.Admin.Commands;
using AppService.Admin.Queries;
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


        private readonly IGetAllSellerProducts _sellerProducts;
        private readonly IGetSellerPavilions _sellerPavilions;
        private readonly IGetAllAuctions _auctions;
        private readonly IGetAllPaidOrders _paidOrders;
        private readonly AppService.Admin.Queries.IGetProduct _product;
        
        #endregion

        #region ctor
        public AdminController(ISeedData data
            ,ILogIn logIn, IGetCustomer customer, IDeactiveUser deactiveUser,
             IMapper mapper, IGetCustomers customers, IEditSeller editSeller
            , IEditCustomer editCustomer, IGetSellers sellers
            , IGetSeller seller, IGetAllSellerProducts sellerProducts
            , IGetSellerPavilions sellerPavilions, IGetAllAuctions auctions
            , IGetAllPaidOrders paidOrders
            , AppService.Admin.Queries.IGetProduct product)
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
           

            _sellerProducts = sellerProducts;
            _sellerPavilions = sellerPavilions;
            _auctions = auctions;
            _paidOrders = paidOrders;
            _product = product;
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
        
        public async Task<IActionResult> ProductProfile(int id, CancellationToken cancellation)
        {
            return View(await _product.Execute(id, cancellation));
        }

        public async Task<IActionResult> SellerProfile(int id, CancellationToken cancellation)
        {
            List<DetailedProductDto> productDtos = new();
            List<PavilionDtoModel> pavilionDtos = new();
            FullDetailSellerViewModel viewModel = _mapper.Map<FullDetailSellerViewModel>(await _seller.Execute(id, cancellation));
            productDtos = await _sellerProducts.Execute(id, cancellation);
            pavilionDtos = await _sellerPavilions.Execute(id, cancellation);

            ViewBag.productDtos = productDtos;
            ViewBag.pavilionDtos = pavilionDtos;
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

        public async Task<IActionResult> GetOrdersList(CancellationToken cancellation)
        {
            List<DetailedDirctOrderDto> dirctOrderDtos = new();
            dirctOrderDtos = await _paidOrders.Execute(cancellation);
            List<DetailedAuctionDto> auctionDtos = await _auctions.Execute(cancellation);
            ViewBag.directOrderDtos = dirctOrderDtos;
            return View(auctionDtos);
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

