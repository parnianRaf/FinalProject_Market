using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AppCore.DtoModels;
using AppCore.DtoModels.Admin;
using AppCore.DtoModels.Auction;
using AppCore.DtoModels.Customer;
using AppCore.DtoModels.DirectOrder;
using AppCore.DtoModels.Product;
using AppCore.DtoModels.Seller;
using AppCore.DtoModels.User;
using AppService.Admin_;
using AppService.Admin_.Command;
using AutoMapper;
using FinalProject_Market.Models;
using FinalProject_Market.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositories.Repository.ProductRepository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject_Market.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class AccountController : Controller
    {
        #region field
        private readonly IAccountAppServices _account;
        private readonly IMapper _mapper;
        private readonly IProductAppService _productAppService;
        private readonly IPavilionAppService _pavilionAppService;

        
        #endregion

        #region ctor
        public AccountController(IAccountAppServices account,
            IMapper mapper, IProductAppService productAppService,
            IPavilionAppService pavilionAppService)
        {
            _account = account;
            _mapper = mapper;
            _productAppService = productAppService;
            _pavilionAppService = pavilionAppService;
        }
        #endregion

        // GET: /<controller>/
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Register(int id)
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
        [AllowAnonymous]
        public async Task<IActionResult> Register(int id, AddUserDto userDto)
        {
            if(ModelState.IsValid)
            {
                switch (id)
                {
                    case 1:
                        var customerResult = await _account.Register("customer", userDto);
                        if (!customerResult.Any())
                        {
                           return RedirectToAction("Index");
                        }
                        customerResult.ToList().ForEach(c => ModelState.AddModelError(string.Empty, c.Description));
                        break;
   
                    case 2:
                        var sellerResult = await _account.Register("seller", userDto);
                        if(!sellerResult.Any())
                        {
                            return RedirectToAction("Index");
                        }
                        sellerResult.ToList().ForEach(s => ModelState.AddModelError(string.Empty, s.Description));
                        break;
                }
            }
            return View(userDto);

        }

        [AllowAnonymous]
        public IActionResult LogIn(int id)
        {
            switch (id)
            {
                case 1:
                    return PartialView();
                case 2:
                    return PartialView("SellerLogIn");
                case 3:
                    return PartialView("LogIn");
            }
            return RedirectToAction("Index");
            
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LogIn(int id,LogInViewModel viewModel,bool IsRememberMe, CancellationToken cancellation)
        {
            if(ModelState.IsValid)
            {
                LogInUser userDto = _mapper.Map<LogInUser>(viewModel);
                ModelState.AddModelError(string.Empty, "یوزر و یا پسورد اشتباه بوده.");
                switch (id)
                {
                    case 1:
                        if(await _account.LogIn("customer",userDto,IsRememberMe))
                        {
                            return View();
                        }
                        break;
                    case 2:
                        if (await _account.LogIn("seller", userDto, IsRememberMe))
                        {
                            return RedirectToAction("MainPage", "SellerManagement", new {area="Seller"});
                        }
                        return PartialView("SellerLogIn",viewModel);

                    case 3:
                        if (await _account.LogIn("admin", userDto, IsRememberMe))
                        {
                            return PartialView("AdminPannel");
                        }
                        break;
                }
            }
            return PartialView(viewModel);
        }
        [AllowAnonymous]
        public async Task<IActionResult> SignOut(int id,CancellationToken cancellation)
        {
            await _account.LogOut(cancellation);
            return RedirectToAction("Index");


        }
       
        public async Task<IActionResult> GetCustomerList(CancellationToken cancellation)
        {
            return View(_mapper.Map<List<GetCustomersViewModel>>( await _account.GetAllUserRoleBased<DetailCustomerDto>("customer")));

        }
    
        public async Task<IActionResult> GetSellerList(CancellationToken cancellation)
        {
            return View(_mapper.Map<List<GetSellersViewModel>>( await _account.GetAllUserRoleBased<DetailSellerDto>("seller")));
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
            return View(viewModel);
        }

        public async Task<IActionResult> SellerProfile(int id, CancellationToken cancellation)
        {
            FullDetailSellerViewModel viewModel = _mapper.Map<FullDetailSellerViewModel>(await _account.GetUser<FullDetailSellerDto>(id, cancellation));
            List<DetailedProductDto> productDtos= await _productAppService.GetAllProducts(id, cancellation);
            List<PavilionDtoModel> pavilionDtos = await _pavilionAppService.GetSellerPavilions(cancellation);

            ViewBag.productDtos = productDtos;
            ViewBag.pavilionDtos = pavilionDtos;
            return View(viewModel);
        }
   
        [HttpPost]
        public async Task<IActionResult> SellerProfile(FullDetailSellerViewModel viewModel, CancellationToken cancellation)
        {
            if (ModelState.IsValid)
            {
                var sellerDto = _mapper.Map<EditUserDto>(viewModel);
                var result = await _account.UpdateUser(sellerDto, cancellation);
                if (result)
                {
                    return RedirectToAction("SellerProfile", new { viewModel.Id });
                }

            }
            return View(viewModel);
        }


        //public async Task<IActionResult> GetOrdersList(CancellationToken cancellation)
        //{
        //    List<DetailedDirctOrderDto> dirctOrderDtos = await _paidOrders.Execute(cancellation);
        //    List<DetailedAuctionDto> auctionDtos = await _auctions.Execute(cancellation);
        //    ViewBag.directOrderDtos = dirctOrderDtos; 
        //    return View(auctionDtos);
        //}
  
        public async Task<IActionResult> DeleteUser(int id, CancellationToken cancellation)
        {
            var deleteResult=await _account.DeleteUser(id,cancellation);
            return RedirectToAction("CustomerProfile", new { id });
        }

        public async Task<IActionResult> ActiveUser(int id, CancellationToken cancellation)
        {
            var ActiveResult = await _account.ActiveUser(id, cancellation);
            return RedirectToAction("CustomerProfile", new { id });
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

