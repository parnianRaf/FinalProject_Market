﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.DtoModels.Product;
using AppService.Admin_;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject_Market.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="admin")]
    public class ProductController : Controller
    {
        #region field
        private readonly IAccountAppServices _account;
        private readonly IMapper _mapper;
        private readonly IProductAppService _productAppService;
        private readonly IPavilionAppService _pavilionAppService;
        #endregion

        #region ctor
        public ProductController(IAccountAppServices account,
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

        public async Task<IActionResult> ProductProfile(int id, CancellationToken cancellation)
        {
            DetailedProductDto detailedProduct = await _productAppService.GetProduct(id,cancellation);
            return View(detailedProduct);
        }

        [HttpPost]
        public async Task<IActionResult> ProductProfile(DetailedProductDto productDto, CancellationToken cancellation)
        {
            if (await _productAppService.EditProduct(productDto,cancellation))
            {
                return RedirectToAction("ProductProfile", new { productDto.Id });
            }
            return View(productDto);
        }

        public async Task<IActionResult> DeleteProduct(int id, CancellationToken cancellation)
        {
            var DeactiveResult = await _productAppService.RemoveProduct(id, cancellation);
            if (DeactiveResult)
            {
                return RedirectToAction("ProductProfile", new { id });
            }
            return RedirectToAction("DeleteProduct", new { id });
        }


        public async Task<IActionResult> ActiveProduct(int id, CancellationToken cancellation)
        {
            await _productAppService.AcceptProduct(id, cancellation);
            return RedirectToAction("ProductProfile", new { id });
        }
        #endregion
    }
}

