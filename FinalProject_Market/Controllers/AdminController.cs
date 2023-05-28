using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.AppServices.Admin.Command;
using AppCore.DtoModels.Admin;
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

        #endregion

        #region ctor
        public AdminController(ISeedData data
            ,ILogIn logIn,
             IMapper mapper)
        {
            _data = data;
            _mapper = mapper;
            _logIn = logIn;
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



        public async Task<IActionResult> SeedData()
        {
            var test1 = await _data.Execute();
            if (!test1)
            {
                return RedirectToAction("Privacy", "Home");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}

