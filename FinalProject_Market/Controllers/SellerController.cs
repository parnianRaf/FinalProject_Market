using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore;
using AppCore.AppServices.Seller.Command;
using AppCore.DtoModels.Product;
using AutoMapper;
using FinalProject_Market.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject_Market.Controllers
{
    public class SellerController : Controller
    {
        #region field
        private readonly IMapper _mapper;
        private readonly IAddProduct _addProduct;

        #endregion

        #region ctor
        public SellerController(IAddProduct addProduct
            , IMapper mapper)
        {
            _addProduct = addProduct;
            _mapper = mapper;
        }
        #endregion


        #region Implementation
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CategorySelect()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategorySelect(int id)
        {
            return RedirectToAction("AddProduct", new { id });
        }
        public IActionResult AddProduct(int id)
        {
            return View(new AddProductViewModel { CategoryId=id});
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductViewModel model,CancellationToken cancellation)
        {
            if(ModelState.IsValid)
            {
                await _addProduct.Execute(_mapper.Map<AddProductDto>(model), cancellation);
                return RedirectToAction("Index","Home");
            }
            return View(model);
   
        }
        #endregion
    }
}

