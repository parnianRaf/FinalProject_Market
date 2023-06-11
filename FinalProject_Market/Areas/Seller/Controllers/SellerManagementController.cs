using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.DtoModels;
using AppCore.DtoModels.Product;
using AppService.Admin_;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject_Market.Areas.Seller.Controllers
{
    [Area("Seller")]
    [Authorize(Roles ="seller")]
    public class SellerManagementController : Controller
    {
        #region field
        private readonly IPavilionAppService _pavilionService;
        #endregion


        #region ctor
        public SellerManagementController(IPavilionAppService pavilionService)
        {
            _pavilionService = pavilionService;
        }
        #endregion


        #region Implementation

        public async Task<IActionResult> MainPage(CancellationToken cancellation)
        {
            List<PavilionDtoModel> productDtos = await _pavilionService.GetSellerPavilions(cancellation);
            return View(productDtos);
        }
        #endregion


    }
}

