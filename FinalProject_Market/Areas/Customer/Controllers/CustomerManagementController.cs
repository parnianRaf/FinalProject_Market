﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore;
using AppCore.DtoModels.Auction;
using AppCore.DtoModels.Comment;
using AppCore.DtoModels.Customer;
using AppCore.DtoModels.DirectOrder;
using AppCore.DtoModels.Offer;
using AppCore.DtoModels.Seller;
using AppCore.DtoModels.User;
using AppService.Admin_;
using AutoMapper;
using FinalProject_Market.Areas.Admin.Models.ViewModels;
using FinalProject_Market.Areas.Customer.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject_Market.Areas.Customer.Controllers
{
    [Area("customer")]
    [Authorize(Roles ="customer")]
    public class CustomerManagementController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductAppService _productAppService;
        private readonly IAccountAppServices _userAppService;
        private readonly IDirectOrderAppService _directOrder;
        private readonly IAuctionAppService _auction;

        public CustomerManagementController(IMapper mapper, IProductAppService productAppService,
            IAccountAppServices userAppService, IDirectOrderAppService directOrder, IAuctionAppService auction)
        {
            _mapper = mapper;
            _productAppService = productAppService;
            _userAppService = userAppService;
            _directOrder = directOrder;
            _auction = auction;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Profile(CancellationToken cancellation)
        {
            switch (await _userAppService.RoleCurrentUser(cancellation))
            {
                case 1:
                    ViewBag.Category = _mapper.Map<List<BaseModel>>(await _productAppService.GetCategories(cancellation));
                    ViewBag.Cart = await _directOrder.GetCurrentDirectOrder(cancellation);
                    ViewBag.LogInUser = new Tuple<bool, EditUserDto>(_userAppService.IsLogedIn(), await _userAppService.GetUser<EditUserDto>(cancellation) ?? new EditUserDto());
                    return View(await _userAppService.GetUser<FullDetailCustomerDto>(cancellation));
                case 2:
                    return RedirectToAction("GetProfile", "SellerManagement",new {area="Seller"});
                case 3:
                    return RedirectToAction("AdminPannel", "Account", new {area="Admin"});
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Profile(FullDetailCustomerDto customerDto, CancellationToken cancellation)
        {
            //ModelState.AddModelError(string.Empty, "تغییر مورد نظر قابل انجام نیست.");
            ViewBag.Category = _mapper.Map<List<BaseModel>>(await _productAppService.GetCategories(cancellation));
            ViewBag.Cart = await _directOrder.GetCurrentDirectOrder(cancellation);
            ViewBag.LogInUser = new Tuple<bool, EditUserDto>(_userAppService.IsLogedIn(), await _userAppService.GetUser<EditUserDto>(cancellation) ?? new EditUserDto());
            await _userAppService.UpdateUser(_mapper.Map<EditUserDto>(customerDto), cancellation);
            return RedirectToAction("Index","Account", new {area="Admin"});
        }

        public async Task<IActionResult> AddToCart(int id,CancellationToken cancellation)
        {
            if(await _directOrder.AddToCart(id, cancellation))
            {
                 return RedirectToAction("Index", "Account", new { area = "Admin" });
            }
            ViewBag.Massage = "شما مجاز به خرید از یک فروشگاه میباشید ابتدا خرید خود را نهایی کنید";
            return RedirectToAction("Index", "Account", new { area = "Admin" });
        }

        public async Task<IActionResult> GetCart(int id,CancellationToken cancellation)
        {
            ViewBag.Category = _mapper.Map<List<BaseModel>>(await _productAppService.GetCategories(cancellation));
            ViewBag.Cart = await _directOrder.GetCurrentDirectOrder(cancellation);
            ViewBag.LogInUser = new Tuple<bool, EditUserDto>(_userAppService.IsLogedIn(), await _userAppService.GetUser<EditUserDto>(cancellation) ?? new EditUserDto());
            return View(await _directOrder.GetDirectOrderCart(id, cancellation));
        }

        public async Task<IActionResult> SubmitOrder(int id,CancellationToken cancellation)
        {
            ViewBag.Category = _mapper.Map<List<BaseModel>>(await _productAppService.GetCategories(cancellation));
            ViewBag.Cart = await _directOrder.GetCurrentDirectOrder(cancellation);
            ViewBag.LogInUser = new Tuple<bool, EditUserDto>(_userAppService.IsLogedIn(), await _userAppService.GetUser<EditUserDto>(cancellation) ?? new EditUserDto());
            return View("Factor", await _directOrder.SubmitOrder(id, cancellation));
        }

        public async Task<IActionResult> AddComment(int id,CancellationToken cancellation)
        {
            ViewBag.Category = _mapper.Map<List<BaseModel>>(await _productAppService.GetCategories(cancellation));
            ViewBag.Cart = await _directOrder.GetCurrentDirectOrder(cancellation);
            ViewBag.LogInUser = new Tuple<bool, EditUserDto>(_userAppService.IsLogedIn(), await _userAppService.GetUser<EditUserDto>(cancellation) ?? new EditUserDto());
            return View(new AddCommentViewModel() {OrderId=id});
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(AddCommentViewModel commentViewModel,CancellationToken cancellation)
        {
            await _directOrder.AddComment(_mapper.Map<AddCommentDto>(commentViewModel), cancellation);
            return RedirectToAction("Index", "Account", new {area="Admin"});
        }

        public async Task<IActionResult> AddOffer(int id,CancellationToken cancellation)
        {
            ViewBag.Category = _mapper.Map<List<BaseModel>>(await _productAppService.GetCategories(cancellation));
            ViewBag.Cart = await _directOrder.GetCurrentDirectOrder(cancellation);
            ViewBag.LogInUser = new Tuple<bool, EditUserDto>(_userAppService.IsLogedIn(), await _userAppService.GetUser<EditUserDto>(cancellation) ?? new EditUserDto());
            return View( new AddOfferViewModel() { AuctionId=id});
        }

        [HttpPost]
        public async Task<IActionResult> AddOffer(AddOfferViewModel viewModel, CancellationToken cancellation)
        {
            if (ModelState.IsValid)
            {
                DetailedOfferDto offerDto = _mapper.Map<DetailedOfferDto>(viewModel);
                await _auction.AddOffer(offerDto, cancellation);
                return RedirectToAction("Index", "Account", new { area = "Admin" });
            }
            ViewBag.Category = _mapper.Map<List<BaseModel>>(await _productAppService.GetCategories(cancellation));
            ViewBag.Cart = await _directOrder.GetCurrentDirectOrder(cancellation);
            ViewBag.LogInUser = new Tuple<bool, EditUserDto>(_userAppService.IsLogedIn(), await _userAppService.GetUser<EditUserDto>(cancellation) ?? new EditUserDto());
            return View(viewModel.AuctionId);
  
        }

        public async Task<IActionResult> OrderHistory (CancellationToken cancellation)
        {
            ViewBag.Category = _mapper.Map<List<BaseModel>>(await _productAppService.GetCategories(cancellation));
            ViewBag.Cart = await _directOrder.GetCurrentDirectOrder(cancellation);
            ViewBag.LogInUser = new Tuple<bool, EditUserDto>(_userAppService.IsLogedIn(), await _userAppService.GetUser<EditUserDto>(cancellation) ?? new EditUserDto());
            return View(new Tuple<List<DetailedDirctOrderDto>, List<DetailedAuctionDto>>(await _directOrder.GetAllCurrentUserPaidDirectOrders(cancellation),await _auction.GetAllPaidAuctions(cancellation))); 
        }



    }
}

