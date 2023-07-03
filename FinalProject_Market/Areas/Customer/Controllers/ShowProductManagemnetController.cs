using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore;
using AppCore.DtoModels.Product;
using AppCore.DtoModels.User;
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
        private readonly IDirectOrderAppService _directOrder;
        private readonly IAccountAppServices _userAppService;
        private readonly IProductAppService _productAppService;
        private readonly IMapper _mapper;

        public ShowProductManagementController(IProductAppService productAppService, IMapper mapper, IDirectOrderAppService directOrder, IAccountAppServices userAppService)
        {
            _productAppService = productAppService;
            _mapper = mapper;
            _directOrder = directOrder;
            _userAppService = userAppService;
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
            ViewBag.Cart = await _directOrder.GetCurrentDirectOrder(cancellation);
            ViewBag.LogInUser = new Tuple<bool, EditUserDto>(_userAppService.IsLogedIn(), await _userAppService.GetUser<EditUserDto>(cancellation) ?? new EditUserDto());
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
            ViewBag.Cart = await _directOrder.GetCurrentDirectOrder(cancellation);
            ViewBag.LogInUser = new Tuple<bool, EditUserDto>(_userAppService.IsLogedIn(), await _userAppService.GetUser<EditUserDto>(cancellation) ?? new EditUserDto());
            ViewBag.Categories = await _productAppService.GetCategory(id, cancellation);
            return View();
        }
    }
}

