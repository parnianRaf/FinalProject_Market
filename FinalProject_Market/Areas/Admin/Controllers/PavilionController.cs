﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.DtoModels;
using AppCore.DtoModels.Product;
using AppService.Admin_;
using AppService.Admin_.Command;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject_Market.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PavilionController : Controller
    {
        #region field
        private readonly IAccountAppServices _account;
        private readonly IMapper _mapper;
        private readonly IProductAppService _productAppService;
        private readonly IPavilionAppService _pavilionAppService;
        #endregion

        #region ctor
        public PavilionController(IAccountAppServices account,
            IMapper mapper, IProductAppService productAppService,
            IPavilionAppService pavilionAppService)
        {
            _account = account;
            _mapper = mapper;
            _productAppService = productAppService;
            _pavilionAppService = pavilionAppService;
        }
    #endregion

    #region Implementation
    // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> PavilionProfile(int id, CancellationToken cancellation)
        {
            PavilionDtoModel detailedProduct = await _pavilionAppService.GetPavilion(id, cancellation);
            return View(detailedProduct);
        }

        [HttpPost]
        public async Task<IActionResult> PavilionProfile(PavilionDtoModel productDto, CancellationToken cancellation)
        {
            if (await _pavilionAppService.EditPavilion(productDto, cancellation))
            {
                return RedirectToAction("PavilionProfile", new { productDto.Id });
            }
            return View(productDto);
        }

        public async Task<IActionResult> DeletePavilion(int id, CancellationToken cancellation)
        {
            var DeactiveResult = await _pavilionAppService.RemovePavilion(id, cancellation);
            if (DeactiveResult)
            {
                return RedirectToAction("PavilionProfile", new { id });
            }
            return RedirectToAction("DeletePavilion", new { id });
        }


        public async Task<IActionResult> ActivePavilion(int id, CancellationToken cancellation)
        {
            await _pavilionAppService.ActiveProduct(id, cancellation);
            return RedirectToAction("PavilionProfile", new { id });
        }


        #endregion

    }
}

