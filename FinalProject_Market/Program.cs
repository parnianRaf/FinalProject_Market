using System.Collections.ObjectModel;
using System.Data;
using AppCore;
using AppCore.AppServices.Seller.Command;
using AppCore.AppServices.Seller.Query;
using AppService.Admin_;
using AppService.Admin_.Command;
using AppService.Seller.Query;
using AppSqlDataBase;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.Repository.ProductRepository;
using Repositories.UserRepository;
using Serilog;
using Serilog.Sinks.MSSqlServer;

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


builder.Services.AddScoped<IAccountAppServices, AccountAppServices>();
builder.Services.AddScoped<IProductAppService, ProductAppService>();
builder.Services.AddScoped<IPavilionAppService, PavilionAppService>();
builder.Services.AddScoped<IAuctionAppService, AuctionAppService>();
builder.Services.AddScoped<IDirectOrderAppService, DirectOrderAppService>();

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


builder.Services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId = "298370143561-0e7qaacf2a5hd6an4vsmbk311oncvp9r.apps.googleusercontent.com";
    googleOptions.ClientSecret = "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";
});

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

app.UseEndpoints(endpoint =>
{
    app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "{area:exists}/{controller=Account}/{action=Index}/{id?}");

    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
});





app.MapRazorPages();

app.Run();

