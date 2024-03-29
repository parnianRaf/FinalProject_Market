﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.DtoModels.Category;
using AppCore.DtoModels.Product;
using AppService.Admin_;
using AutoMapper;
using FinalProject_Market.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject_Market.Areas.Admin.Controllers
{
    [Area("seller")]
    [Authorize(Roles = "seller")]
    public class ProductManagementController : Controller
    {
        #region field
        private readonly IAccountAppServices _account;
        private readonly IMapper _mapper;
        private readonly IProductAppService _productAppService;
        private readonly IPavilionAppService _pavilionAppService;
        private readonly IDirectOrderAppService _directOrderAppService;
        #endregion

        #region ctor
        public ProductManagementController(IAccountAppServices account,
            IMapper mapper, IProductAppService productAppService,
            IPavilionAppService pavilionAppService, IDirectOrderAppService directOrderAppService)
        {
            _account = account;
            _mapper = mapper;
            _productAppService = productAppService;
            _pavilionAppService = pavilionAppService;
            _directOrderAppService = directOrderAppService;
        }
        #endregion

        #region Implementation
        // GET: /<controller>/


        public async Task<IActionResult> SelectCategory(CancellationToken cancellation)
        {
            List<CategoryViewModel> categoryDtoModels =_mapper.Map<List<CategoryViewModel>>( await  _productAppService.GetCategories(cancellation));
            ViewBag.Massages = await _directOrderAppService.GetSellerComments(cancellation);
            return View("CategoryProduct" , categoryDtoModels);
        }

        public async Task<IActionResult> AddProduct(int id,CancellationToken cancellation)
        {
            await _productAppService.GetCategory(id, cancellation);
            ViewBag.Massages = await _directOrderAppService.GetSellerComments(cancellation);
            return View("AddProduct");
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductDto productDto,CancellationToken cancellation)
        {
            if(ModelState.IsValid)
            {
                await _productAppService.AddProduct(productDto, cancellation);
                return RedirectToAction("MainPage", "SellerManagement");
            }
            return View();
        }





        public async Task<IActionResult> ProductProfile(int id, CancellationToken cancellation)
        {
            DetailedProductDto detailedProduct = await _productAppService.GetProduct(id,cancellation);
            ViewBag.Massages = await _directOrderAppService.GetSellerComments(cancellation);
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

