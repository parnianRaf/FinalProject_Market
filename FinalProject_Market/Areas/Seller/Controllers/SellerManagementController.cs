using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject_Market.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class SellerManagementController : Controller
    {
        // GET: /<controller>/
        public IActionResult st()
        {
            return View();
        }
    }
}

