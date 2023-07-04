using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.DtoModels;
using AppCore.DtoModels.Customer;
using AppCore.DtoModels.Product;
using AppCore.DtoModels.Seller;
using AppCore.DtoModels.User;
using AppService.Admin_;
using AutoMapper;
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
        private readonly IAccountAppServices _accountAppService;
        private readonly IMapper _mapper;
        #endregion


        #region ctor
        public SellerManagementController(IPavilionAppService pavilionService,IAccountAppServices accountAppService, IMapper mapper)
        {
            _pavilionService = pavilionService;
            _accountAppService = accountAppService;
            _mapper = mapper;
        }
        #endregion


        #region Implementation

        public async Task<IActionResult> MainPage(CancellationToken cancellation)
        {
            List<PavilionDtoModel> pavilionDtos = await _pavilionService.GetSellerPavilions(cancellation);
            ViewBag.Massages=
            return View(pavilionDtos);
        }

        public async Task<IActionResult> GetProfile(CancellationToken cancellation)
        {
            Tuple<SellerOverViewDto, FullDetailSellerDto> sellerDto =await _accountAppService.GetCurrentUserProfile<FullDetailSellerDto>(cancellation);
            ViewBag.FullDetailSellerViewModel = sellerDto.Item1;
            return View(sellerDto.Item2);
        }

        [HttpPost]
        public async Task<IActionResult> GetProfile(FullDetailSellerViewModel viewModel, CancellationToken cancellation)
        {
                var sellerDto = _mapper.Map<EditUserDto>(viewModel);
                var result = await _accountAppService.UpdateUser(sellerDto, cancellation);
                if (result)
                {
                    return RedirectToAction("GetProfile", new { viewModel.Id });
                }

           
            return View(viewModel);
        }
        #endregion


    }
}

