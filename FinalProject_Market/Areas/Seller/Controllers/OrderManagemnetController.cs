using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.DtoModels.Auction;
using AppCore.DtoModels.DirectOrder;
using AppService.Admin_;
using FinalProject_Market.Cache;
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
        private readonly Medal _medal;
        #endregion

        #region ctor
        public OrderManagemnetController(IAuctionAppService auctionAppService,
            IDirectOrderAppService directOrderAppService,
            Medal medal)
        {
            _auctionAppService = auctionAppService;
            _directOrderAppService = directOrderAppService;
            _medal = medal;
        }
        #endregion

        #region Implementation
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
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

        public async Task<IActionResult> AddOrder()
        {
            var x = _medal.MedalDiscount;
            var y = _medal.MedalPrice;
        }
        #endregion

    }
}

