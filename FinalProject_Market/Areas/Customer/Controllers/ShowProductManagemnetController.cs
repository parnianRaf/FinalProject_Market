using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.DtoModels.Product;
using AppService.Admin_;
using AutoMapper;
using FinalProject_Market.Areas.Admin.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject_Market.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles ="customer")]
    public class ShowProductManagementController : Controller
    {
        private readonly IProductAppService _productAppService;
        private readonly IMapper _mapper;

        public ShowProductManagementController(IProductAppService productAppService, IMapper mapper)
        {
            _productAppService = productAppService;
            _mapper = mapper;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> GetProduct(int id, CancellationToken cancellation)
        {
            ViewBag.Category = _mapper.Map<List<BaseModel>>(await _productAppService.GetCategories(cancellation));
            ViewBag.Products= await _productAppService.GetProduct(id, cancellation);
            return View();
        }

        //public async Task<IActionResult> GetCategoryProduct(int categoryId,CancellationToken cancellation)
        //{
        //    ViewBag.Products = await _productAppService.GetCategoryProducts(categoryId, cancellation);
        //    return View(_mapper.Map<List<BaseModel>>(await _productAppService.GetCategories(cancellation)));
        //}


        [AllowAnonymous]
        public async Task<IActionResult> GetCategory(int id,CancellationToken cancellation)
        {
            ViewBag.Category = _mapper.Map<List<BaseModel>>(await _productAppService.GetCategories(cancellation));
            ViewBag.Categories = await _productAppService.GetCategory(id, cancellation);
            return View();
        }
    }
}

