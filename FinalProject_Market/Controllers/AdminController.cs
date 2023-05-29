using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.AppServices.Admin.Command;
using AppCore.AppServices.Admin.Query;
using AppCore.DtoModels.Admin;
using AppCore.DtoModels.Customer;
using AppService.Admin;
using AutoMapper;
using FinalProject_Market.Models;
using FinalProject_Market.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject_Market.Controllers
{
    public class AdminController : Controller
    {
        #region field

        private readonly ISeedData _data;
        private readonly IMapper _mapper;
        private readonly ILogIn _logIn;
        private readonly IGetCustomers _customers;
        private readonly IGetCustomer _customer;
        private readonly IEditCustomer _editCustomer;

        #endregion

        #region ctor
        public AdminController(ISeedData data
            ,ILogIn logIn, IGetCustomer customer,
             IMapper mapper, IGetCustomers customers
            , IEditCustomer editCustomer)
        {
            _data = data;
            _mapper = mapper;
            _logIn = logIn;
            _customers = customers;
            _customer = customer;
            _editCustomer = editCustomer;
        }
        #endregion

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LogIn()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel viewModel,CancellationToken cancellation)
        {
            LogInAdminDto adminDto = _mapper.Map<LogInAdminDto>(viewModel);


                var logInResult =await _logIn.Execute(adminDto, cancellation);
                if(logInResult.Succeeded)
                {
                    return PartialView("AdminPannel");
                }
                ModelState.AddModelError(string.Empty, "یوزر یا پسورد اشتباه بوده...");
            
            return PartialView(viewModel);

        }

        [HttpPost]
        public async Task<IActionResult> Profile (FullDetailCustomerViewModel viewModel,CancellationToken cancellation)
        {
            var customer = _mapper.Map<EditCustomerDto>(viewModel);
            var result = await _editCustomer.Execute(customer, cancellation);
            if (result.Succeeded)
            {
                return RedirectToAction("Index","Home");
            }
            return View(viewModel);
        }

        public async Task<IActionResult> GetCustomerList(CancellationToken cancellation)
        {
            List<DetailCustomerDto> customerDtos =await  _customers.Execute(cancellation);
            List<GetCustomersViewModel> customersViewModels = _mapper.Map<List<GetCustomersViewModel>>(customerDtos);
            return PartialView(customersViewModels);
        }

        public async Task<IActionResult> Profile(int id,CancellationToken cancellation)
        {
            FullDetailCustomerViewModel viewModel= _mapper.Map<FullDetailCustomerViewModel>(await _customer.Execute(id, cancellation));
            return View(viewModel);
        }

        //public async Task<IActionResult> SeedData()
        //{

        //    var test1 = await _data.Execute();
        //    if (!test1)
        //    {
        //        return RedirectToAction("Privacy", "Home");
        //    }
        //    return RedirectToAction("Index", "Home");

        //}
    }
}

