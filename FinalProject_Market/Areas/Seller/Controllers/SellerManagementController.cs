﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore;
using AppCore.DtoModels;
using AppCore.DtoModels.Auction;
using AppCore.DtoModels.Customer;
using AppCore.DtoModels.DirectOrder;
using AppCore.DtoModels.Product;
using AppCore.DtoModels.Seller;
using AppCore.DtoModels.User;
using AppService.Admin_;
using AutoMapper;
using FinalProject_Market.Areas.Admin.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject_Market.Areas.Seller.Controllers
{
    [Area("seller")]
    [Authorize(Roles ="seller")]
    public class SellerManagementController : Controller
    {
        #region field
        private readonly IPavilionAppService _pavilionService;
        private readonly IDirectOrderAppService _directOrderAppService;
        private readonly IAuctionAppService _auctionAppService;
        private readonly IAccountAppServices _accountAppService;
        private readonly IMapper _mapper;
        #endregion


        #region ctor
        public SellerManagementController(IPavilionAppService pavilionService, IAccountAppServices accountAppService, IMapper mapper, IAuctionAppService auctionAppService, IDirectOrderAppService directOrderAppService)
        {
            _pavilionService = pavilionService;
            _accountAppService = accountAppService;
            _mapper = mapper;
            _auctionAppService = auctionAppService;
            _directOrderAppService = directOrderAppService;
        }
        #endregion


        #region Implementation

        public async Task<IActionResult> MainPage(CancellationToken cancellation)
        {
            List<PavilionDtoModel> pavilionDtos = await _pavilionService.GetSellerPavilions(cancellation);
            ViewBag.Massages = await _directOrderAppService.GetSellerComments(cancellation);
            return View(pavilionDtos);
        }

        public async Task<IActionResult> GetProfile(CancellationToken cancellation)
        {
            Tuple<SellerOverViewDto, FullDetailSellerDto> sellerDto =await _accountAppService.GetCurrentUserProfile<FullDetailSellerDto>(cancellation);
            ViewBag.FullDetailSellerViewModel = sellerDto.Item1;
            ViewBag.Massages = await _directOrderAppService.GetSellerComments(cancellation);
            return View(sellerDto.Item2);
        }

        [HttpPost]
        public async Task<IActionResult> GetProfile(FullDetailSellerViewModel viewModel, CancellationToken cancellation)
        {
            var sellerDto = _mapper.Map<EditUserDto>(viewModel);
            var result = await _accountAppService.UpdateUser(sellerDto, cancellation);
            ViewBag.Massages = await _directOrderAppService.GetSellerComments(cancellation);
            return result ? RedirectToAction("GetProfile", new { viewModel.Id }) : View(viewModel);
        }

        public async Task<IActionResult> OrderHistory(CancellationToken cancellation)
        {
            ViewBag.Massages = await _directOrderAppService.GetSellerComments(cancellation);
            return View(new Tuple<List<DetailedDirctOrderDto>, List<DetailedAuctionDto>>(await _directOrderAppService.GetAllCurrentUserPaidDirectOrders(cancellation), await _auctionAppService.GetAllPaidAuctions(cancellation)));
        }
        #endregion


    }
}

