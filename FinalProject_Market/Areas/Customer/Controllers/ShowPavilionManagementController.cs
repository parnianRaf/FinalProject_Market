using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class ShowPavilionManagementController : Controller
    {
        private readonly IPavilionAppService _pavilionAppService;
        private readonly IProductAppService _productAppService;
        private readonly IMapper _mapper;

        public ShowPavilionManagementController(IPavilionAppService pavilionAppService, IProductAppService productAppService, IMapper mapper)
        {
            _pavilionAppService = pavilionAppService;
            _productAppService = productAppService;
            _mapper = mapper;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> GetPavilion(int id,CancellationToken cancellation)
        {
            ViewBag.Category = _mapper.Map<List<BaseModel>>(await _productAppService.GetCategories(cancellation));
            ViewBag.Pavilion = await _pavilionAppService.GetPavilion(id, cancellation);
            return View();
        }
    }
}

