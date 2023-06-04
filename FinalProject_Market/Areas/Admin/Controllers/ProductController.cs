using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.DtoModels.Product;
using AppService.Admin_;
using AppService.Admin_.Command;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject_Market.Areas.Admin.Controllers
{
    [Area("Admin")]
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
        public IActionResult Index()
        {
            return View();
        }
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
        #endregion
    }
}

