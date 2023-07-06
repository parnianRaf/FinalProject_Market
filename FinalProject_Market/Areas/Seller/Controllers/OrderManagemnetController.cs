using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore;
using AppCore.DtoModels.Auction;
using AppCore.DtoModels.DirectOrder;
using AppCore.DtoModels.Product;
using AppService.Admin_;
using AutoMapper;
using FinalProject_Market.Cache;
using FinalProject_Market.Models.ViewModels;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositories.Repository.ProductRepository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject_Market.Areas.Admin.Controllers
{
    [Area("seller")]
    [Authorize(Roles ="seller")]
    public class OrderManagemnetController : Controller
    {
        #region field
        private readonly IAuctionAppService _auctionAppService;
        private readonly IDirectOrderAppService _directOrderAppService;
        private readonly IProductAppService _productAppService;
        private readonly IMapper _mapper;

        #endregion

        #region ctor
        public OrderManagemnetController(IAuctionAppService auctionAppService,
            IDirectOrderAppService directOrderAppService,
            IProductAppService productAppService,
            IMapper mapper)
        {
            _auctionAppService = auctionAppService;
            _directOrderAppService = directOrderAppService;
            _productAppService = productAppService;
            _mapper = mapper;

        }
        #endregion

        #region Implementation
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddAuction(CancellationToken cancellation)
        {
            ViewBag.Products =await _productAppService.GetAllSellerProducts(cancellation);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAuction(AddAuctionViewModel auctionViewModel, CancellationToken cancellation)
        {
            if (ModelState.IsValid)
            {
                AddAuctionDto auctionDto = _mapper.Map<AddAuctionDto>(auctionViewModel);
                Auction auction = await _auctionAppService.AddAuction(auctionDto, cancellation);
                BackgroundJob.Schedule<IAuctionAppService>(s => s.UpdateAuctions(_mapper.Map<AuctionTime>(auction), cancellation), auction.StartTime);
                BackgroundJob.Schedule<IAuctionAppService>(s => s.UpdateAuctions(_mapper.Map<AuctionTime>(auction), cancellation), auction.EndTime);
                return RedirectToAction("Index", "Account", new { area = "admin" });
            }
            var x = ModelState;
            ViewBag.Products = await _productAppService.GetAllSellerProducts(cancellation);
            return View(auctionViewModel);
        }


        public IActionResult ValidateDateEqualOrGreater(DateTime StartTime)
        {
            var result= Json(StartTime >= DateTime.Now);
            return result;
        }


        public async Task<IActionResult> GetOrdersList(CancellationToken cancellation)
        {
            List<DetailedDirctOrderDto> dirctOrderDtos =await  _directOrderAppService.GetAllDirectOrder(cancellation);
            List<DetailedAuctionDto> auctionDtos = await _auctionAppService.GetAllAuctions(cancellation);
            ViewBag.directOrderDtos = dirctOrderDtos;
            return View(auctionDtos);
        }

        public async Task<IActionResult> OrderAcceptComment(int id,CancellationToken cancellation)
        {
            var result = await _directOrderAppService.AcceptComment(id, cancellation);
            if (result)
            {
                return RedirectToAction("GetOrdersList");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AuctionAcceptComment(int id, CancellationToken cancellation)
        {
            var result = await _auctionAppService.AcceptComment(id, cancellation);
            if (result)
            {
                return RedirectToAction("GetOrdersList");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> OrderRejectComment(int id, CancellationToken cancellation)
        {
            var result = await _directOrderAppService.RejectComment(id, cancellation);
            if (result)
            {
                return RedirectToAction("GetOrdersList");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AuctionRejectComment(int id, CancellationToken cancellation)
        {
            var result = await _auctionAppService.RejectComment(id, cancellation);
            if (result)
            {
                return RedirectToAction("GetOrdersList");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AuctionOperation(int auctionId,CancellationToken cancellation)
        {
            
            return View();
        }
        #endregion

    }
}

