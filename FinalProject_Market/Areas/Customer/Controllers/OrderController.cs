using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.DtoModels.Auction;
using AppCore.DtoModels.DirectOrder;
using AppService.Admin_;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositories.Repository.ProductRepository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject_Market.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="admin")]
    public class OrderController : Controller
    {
        #region field
        private readonly IAuctionAppService _auctionAppService;
        private readonly IDirectOrderAppService _directOrderAppService;
        #endregion

        #region ctor
        public OrderController(IAuctionAppService auctionAppService,
            IDirectOrderAppService directOrderAppService)
        {
            _auctionAppService = auctionAppService;
            _directOrderAppService = directOrderAppService;
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
        #endregion

    }
}

