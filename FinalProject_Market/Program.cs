﻿using AppCore;
using AppCore.AppServices.Admin.Command;
using AppCore.AppServices.Admin.Query;
using AppCore.AppServices.Admin_.Command;
using AppCore.AppServices.Admin_.Query;
using AppCore.AppServices.Seller.Command;
using AppCore.AppServices.Seller.Query;
using AppService.Admin;
using AppService.Admin.Commands;
using AppService.Admin.Queries;
using AppService.Seller.Query;
using AppSqlDataBase;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.Repository.ProductRepository;
using Repositories.UserRepository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MarketContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ISellerRepository, SellerRepository>();
builder.Services.AddScoped<IPavilionRepository, PavilionRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();
builder.Services.AddScoped<IDirectOrderRepository, DirectOrderRepository>();
builder.Services.AddScoped<ILogIn, LogIn>();
builder.Services.AddScoped<IGetCustomers, GetCustomers>();
builder.Services.AddScoped<IGetSeller, GetSeller>();
builder.Services.AddScoped<IGetSellers, GetSellers>();
builder.Services.AddScoped<IGetCustomer, GetCustomer>();
builder.Services.AddScoped<IEditCustomer, EditCustomer>();
builder.Services.AddScoped<IEditSeller, EditSeller>();
builder.Services.AddScoped<IDeactiveUser, DeactiveUser>();
builder.Services.AddScoped<IDeactiveUser, DeactiveUser>();
builder.Services.AddScoped<AppService.Admin.Queries.IGetProduct, GetProduct>();
builder.Services.AddScoped<IGetAllSellerProducts, GetAllSellerProducts>();
builder.Services.AddScoped<IGetSellerPavilions, GetSellerPavilions>();
builder.Services.AddScoped<IGetAllAuctions, GetAllAuctions>();
builder.Services.AddScoped<IGetAllPaidOrders, GetAllPaidOrders>();
builder.Services.AddScoped<IGetCommissionPaidBySeller, GetCommissionPaidBySeller>();
builder.Services.AddScoped<IGetCommissionPaidBySellerAuction, GetCommissionPaidBySellerAuction>();
builder.Services.AddScoped<IDeactiveProduct, DeactiveProduct>();
builder.Services.AddScoped<AppCore.AppServices.Admin_.Command.IEditProduct, EditProduct>();
builder.Services.AddScoped<IActiveProduct, ActiveProduct>();

//builder.Services.AddScoped<IAddProduct, AddPtoduct>();
//builder.Services.AddScoped<IGetCategories, GetCategories>();
builder.Services.AddScoped<ISeedData, SeedData>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddIdentity<User, IdentityRole<int>>(option =>
{
    option.Password.RequireDigit = true;
    option.Password.RequiredLength = 8;
    option.Password.RequireNonAlphanumeric = true;
    option.Password.RequireUppercase = true;

    option.SignIn.RequireConfirmedAccount = false;
    option.SignIn.RequireConfirmedEmail = false;
    option.SignIn.RequireConfirmedPhoneNumber = false;

    option.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<MarketContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "Admin",
//    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

