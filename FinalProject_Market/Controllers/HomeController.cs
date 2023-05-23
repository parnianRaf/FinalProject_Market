using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FinalProject_Market.Models;
using Microsoft.AspNetCore.Identity;

namespace FinalProject_Market.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<IdentityUser<int>> _userManager;
    private readonly SignInManager<IdentityUser<int>> _signInManager;
    private readonly RoleManager<IdentityRole<int>> _roleManager;

    public HomeController(ILogger<HomeController> logger
        , UserManager<IdentityUser<int>> userManager
        , SignInManager<IdentityUser<int>> signInManager
        , RoleManager<IdentityRole<int>> roleManager)
    {
        _logger = logger;
        _signInManager = signInManager;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> SeedData()
    {
        var adminRoleResult = await _roleManager.CreateAsync(new IdentityRole<int>("Admin"));
        var customerRoleResult= await _roleManager.CreateAsync(new IdentityRole<int>("Customer"));

        var customerUserResult = await _userManager.CreateAsync(new IdentityUser<int>("Amin"));
        if(adminRoleResult.Succeeded)
        {
            var adminUser = await _userManager.FindByNameAsync("amin");
            await _userManager.AddToRoleAsync(adminUser, "Admin");
        }
        var testResullt1 = await _userManager.CreateAsync(new IdentityUser<int>("test"));
        if (testResullt1.Succeeded)
        {
            var testUser = await _userManager.FindByNameAsync("test");
            await _userManager.AddToRoleAsync(testUser, "Customer");
        }
        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

