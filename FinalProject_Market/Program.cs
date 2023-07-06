using System.Collections.ObjectModel;
using System.Data;
using System.Security.Cryptography;
using AppCore;
using AppCore.Contracts.AppServices;
using AppService.Admin_;
using AppSqlDataBase;
using FinalProject_Market.Cache;
using Hangfire;
using Hangfire.Dashboard;
using HangfireBasicAuthenticationFilter;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using NetCore.AutoRegisterDi;
using Repositories.Repository.ProductRepository;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MarketContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.RegisterAssemblyPublicNonGenericClasses(typeof(CategoryRepository).Assembly)
    .Where(s => s.Name.EndsWith("Repository"))
    .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);

builder.Services
  .RegisterAssemblyPublicNonGenericClasses(typeof(MapServices).Assembly)
  .Where(c => c.Name.EndsWith("Service")|| c.Name.EndsWith("Services"))
  .IgnoreThisInterface<IHostedService>()
  .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);

builder.Services
  .RegisterAssemblyPublicNonGenericClasses(typeof(AccountAppServices).Assembly)
  .Where(c => c.Name.EndsWith("AppService") || c.Name.EndsWith("AppServices"))
  .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);



builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.Development.json",false,true)
    .AddJsonFile("appsettings.json");



builder.Services.AddHangfire(x => x.UseSqlServerStorage(()=>new Microsoft.Data.SqlClient.SqlConnection(builder.Configuration.GetConnectionString("HangFire"))));
builder.Services.AddHangfireServer();






var configs = builder.Configuration.GetSection("Medal").Get<Medal>();
var config2 = builder.Configuration.GetSection("CronsAuction").Get<CronsAuction>();
builder.Services.AddSingleton<Medal>(configs);
builder.Services.AddSingleton<CronsAuction>(config2);



builder.Services.AddDatabaseDeveloperPageExceptionFilter();


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
    .AddDefaultUI()
    .AddEntityFrameworkStores<MarketContext>();

builder.Services.AddControllersWithViews();




var sinkOpt = new MSSqlServerSinkOptions()
{
     AutoCreateSqlDatabase=true,
      AutoCreateSqlTable=true,
       TableName="UserLog",
        SchemaName="dbo",
         BatchPeriod=TimeSpan.FromSeconds(10)
};
var columnOpt = new ColumnOptions()
{
     AdditionalColumns=new Collection<SqlColumn>()
     {
           new SqlColumn()
           {
                AllowNull=false, ColumnName="UserName", DataType=SqlDbType.NVarChar
           }
     }

};
columnOpt.Store.Remove(StandardColumn.MessageTemplate);

Log.Logger = new LoggerConfiguration()
    .WriteTo.MSSqlServer(builder.Configuration.GetConnectionString("UserLog"),sinkOptions:sinkOpt,columnOptions:columnOpt)
    .CreateLogger();









//builder.Services.AddAuthentication().AddGoogle(googleOptions =>
//{
//    googleOptions.ClientId = "298370143561-0e7qaacf2a5hd6an4vsmbk311oncvp9r.apps.googleusercontent.com";
//    googleOptions.ClientSecret = "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";
//});

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

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

app.UseHangfireDashboard("/hangfire",new DashboardOptions
{
    DashboardTitle="HangfireDashBoard",
    Authorization = new[]
    {
        new HangfireCustomBasicAuthenticationFilter
        {
            User=builder.Configuration.GetSection("HangFirePassword:userName").Value,
            Pass=builder.Configuration.GetSection("HangFirePassword:password").Value
        }
    }

});



app.UseEndpoints(endpoint =>
{
    app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "{area:exists}/{controller=Account}/{action=Index}/{id?}");

    app.MapAreaControllerRoute(
   name: "Seller",
   areaName: "Seller",
   pattern: "{area:exists}/{controller=SellerManagement}/{action=Index}/{id?}");

    app.MapAreaControllerRoute(
name: "Customer",
areaName: "Customer",
pattern: "{area:exists}/{controller=ShowProductManagement}/{action=Index}/{id?}");

    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
});





app.MapRazorPages();

app.Run();

