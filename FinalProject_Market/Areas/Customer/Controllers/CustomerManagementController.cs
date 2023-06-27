using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.DtoModels.Customer;
using AppCore.DtoModels.DirectOrder;
using AppCore.DtoModels.User;
using AppService.Admin_;
using AppService.Admin_.Command;
using AutoMapper;
using FinalProject_Market.Areas.Admin.Models.ViewModels;
using FinalProject_Market.Areas.Customer.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject_Market.Areas.Customer.Controllers
{
    [Area("customer")]
    [Authorize(Roles ="customer")]
    public class CustomerManagementController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductAppService _productAppService;
        private readonly IAccountAppServices _userAppService;
        private readonly IDirectOrderAppService _directOrder;

        public CustomerManagementController(IMapper mapper, IProductAppService productAppService,
            IAccountAppServices userAppService, IDirectOrderAppService directOrder)
        {
            _mapper = mapper;
            _productAppService = productAppService;
            _userAppService = userAppService;
            _directOrder = directOrder;
        }


        public async Task<IActionResult> Profile(CancellationToken cancellation)
        {
            ViewBag.Category = _mapper.Map<List<BaseModel>>(await _productAppService.GetCategories(cancellation));
            return View(await _userAppService.GetUser<FullDetailCustomerDto>(cancellation));
        }

        [HttpPost]
        public async Task<IActionResult> Profile(FullDetailCustomerDto customerDto, CancellationToken cancellation)
        {
            //ModelState.AddModelError(string.Empty, "تغییر مورد نظر قابل انجام نیست.");
            ViewBag.Category = _mapper.Map<List<BaseModel>>(await _productAppService.GetCategories(cancellation));
            //if (ModelState.IsValid)
            //{
            await _userAppService.UpdateUser(_mapper.Map<EditUserDto>(customerDto), cancellation);
            return RedirectToAction("Index","Account", new {area="Admin"});
            //}
            //return View(customerDto);
        }

        public async Task<IActionResult> AddToCart(int id,CancellationToken cancellation)
        {
            if(await _directOrder.AddToCart(id, cancellation))
            {
                 return RedirectToAction("Index", "Account", new { area = "Admin" });
            }
            ViewBag.Massage = "شما مجاز به خرید از یک فروشگاه میباشید ابتدا خرید خود را نهایی کنید";
            return RedirectToAction("Index", "Account", new { area = "Admin" });
        }

        public async Task<IActionResult> GetCart(int id,CancellationToken cancellation)
        {
            ViewBag.Category = _mapper.Map<List<BaseModel>>(await _productAppService.GetCategories(cancellation));
            return View(await _directOrder.GetDirectOrderCart(id, cancellation));
        }

        public async Task<IActionResult> SubmitOrder(int id,CancellationToken cancellation)
        {
            ViewBag.Category = _mapper.Map<List<BaseModel>>(await _productAppService.GetCategories(cancellation));
            return View("Factor", await _directOrder.SubmitOrder(id, cancellation));
        }

        public async Task<IActionResult> AddComment(CancellationToken cancellation)
        {
            ViewBag.Category = _mapper.Map<List<BaseModel>>(await _productAppService.GetCategories(cancellation));
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(AddCommentViewModel commentViewModel)
        {




            return RedirectToAction("Index", "Account", new {area="Admin"});
        }

        
    }
}

