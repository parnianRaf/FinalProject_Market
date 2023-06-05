using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.DtoModels.Auction;
using AppCore.DtoModels.DirectOrder;
using AppService.Admin_;
using Microsoft.AspNetCore.Mvc;
using Repositories.Repository.ProductRepository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject_Market.Areas.Admin.Controllers
{
    [Area("Admin")]
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
        //public async Task<IActionResult> AuctionProfile(int id, CancellationToken cancellation)
        //{
        //    var detailedProduct = await _getAuction.Execute(id, cancellation);
        //    return View(detailedProduct);
        //}

        //[HttpPost]
        //public async Task<IActionResult> AuctionProfile(DetailedProductDto productDto, CancellationToken cancellation)
        //{
        //    if (await _editProduct.Execute(productDto, cancellation))
        //    {
        //        return RedirectToAction("ProductProfile", new { productDto.Id });
        //    }
        //    return View(productDto);
        //}

        //public async Task<IActionResult> GetOrdersList(CancellationToken cancellation)
        //{

        //}
        #endregion

    }
}

