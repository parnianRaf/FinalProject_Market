using System;
using AppCore;
using AppCore.DtoModels.User;
using AppSqlDataBase;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Runtime.Serialization;
using Serilog;
using Microsoft.AspNetCore.Http;
using Service;
using AppCore.Contracts.AppServices;
using AppCore.DtoModels.Customer;
using Microsoft.Extensions.Options;
using AppCore.DtoModels.Seller;

namespace AppService.Admin_
{
    public class AccountAppServices : IAccountAppServices
    {
        #region field
        private readonly IAccountServices _accountService;
        private readonly ISellerStatusService _sellerStatus;
        private readonly IMapServices _mapService;
        private readonly IImageService _imageService;
        private readonly UserManager<User> _userManager;
        #endregion

        #region ctor
        public AccountAppServices(IAccountServices accountService,
            IMapServices mapService, UserManager<User> userManager,
            ISellerStatusService sellerStatus, IImageService imageService)
        {

            _accountService = accountService;
            _mapService = mapService;
            _userManager = userManager;
            _sellerStatus = sellerStatus;
            _imageService = imageService;
        }
        #endregion

        #region Implementation
        public async Task<IEnumerable<IdentityError>> Register(string role, AddUserDto userDto)
        {
            User user = _mapService.MapUser<AddUserDto>(userDto);

            IEnumerable<IdentityError> createErrors = await _accountService.CreateUser(user, userDto.Password);
            if (!createErrors.Any())
            {
                if (await _accountService.IsRoleExist(role))
                {
                    var roleErrors = await _accountService.AddToRole(user, role);
                    roleErrors.ToList().ForEach(r => createErrors.Append(r));
                    await _accountService.SetCreateField(user);
                }

            }
  
            return createErrors;
        }

        //public async Task<bool> AddToAdmin(User user, CancellationToken cancellation)
        //{
        //    var addRoleResult = await _userManager.AddToRoleAsync(user, "admin");
        //    if (addRoleResult.Succeeded)
        //    {
        //        return true;
        //    }
        //    return false;

        //}

        //public async Task<bool> AddToCustomer(User user, CancellationToken cancellation)
        //{
        //    var addRoleResult = await _userManager.AddToRoleAsync(user, "customer");
        //    if (addRoleResult.Succeeded)
        //    {
        //        return true;
        //    }
        //    return false;

        //}

        //public async Task<bool> AddToSeller(User user, CancellationToken cancellation)
        //{
        //    var addRoleResult = await _userManager.AddToRoleAsync(user, "seller");
        //    if (addRoleResult.Succeeded)
        //    {
        //        return true;
        //    }
        //    return false;

        //}

        public bool IsLogedIn()
        {
            return GetUserId() is not 0 ? true : false;
        }

        public int GetUserId()
        {
            return _accountService.GetCurrentUser();
        }

        public async Task<bool> LogIn(string role, LogInUser userDto, bool IsRememberMe)
        {
            bool signInResult = false;
            User user = await _accountService.GetUser(userDto);
            if (await _accountService.IsInRole(user, role))
            {
                signInResult = await _accountService.SignIn(user, userDto.Password, IsRememberMe);
            }
            return signInResult;
        }

        public async Task LogOut(CancellationToken cancellation)
        {
            await _accountService.SignOut();
        }

        public async Task<List<T>> GetAllUserRoleBased<T>(string role)
        {
            if (await _accountService.IsRoleExist(role))
            {
                List<User> users = await _accountService.GetAllUserRoleBAsed(role);
                return _mapService.MapUser<T>(users);
            }
            return new List<T>();

        }

        public async Task<T> GetUserProfile<T>( CancellationToken cancellation)
        {
            User user =await _userManager.FindByIdAsync( _accountService.GetCurrentUser().ToString()) ?? new User();
            var userDto = _mapService.MapUser<T>(user);
            return userDto;
        }

        public async Task<Tuple<SellerOverViewDto, T>> GetCurrentUserProfile<T>(CancellationToken cancellation)
        {
            int userId = _accountService.GetCurrentUser();
            User user = await _accountService.GetUser(userId);
            var userDto = _mapService.MapUser<T>(user);
            SellerOverViewDto sellerOverView = await _sellerStatus.SellerOverView(user);
            return new Tuple<SellerOverViewDto, T>(sellerOverView,userDto);
        }

        public async Task<List<IdentityError>> DeleteUser(int id, CancellationToken cancellationToken)
        {
            User user = await _accountService.GetUser(id);
            return await _accountService.DeleteUser(user);
        }

        public async Task<bool> ActiveUser(int id, CancellationToken cancellation)
        {
            bool result = false;
            User user = await _accountService.GetUser(id);
            return await _accountService.ActiveUser(user);
        }

        public async Task<T> GetUser<T>(int id, CancellationToken cancellation)
        {
            User user = await _accountService.GetUser(id);
            return _mapService.MapUser<T>(user);
        }

        public async Task<T> GetUser<T>( CancellationToken cancellation)
        {
            User user = await _accountService.GetUser(_accountService.GetCurrentUser());
            return _mapService.MapUser<T>(user);
        }

        public async Task<bool> UpdateUser(EditUserDto userDto, CancellationToken cancellation)
        {
            User user = await _accountService.GetUser(userDto.Id);
            userDto.FilePathSource =_imageService.GetFilePath(user.UserName, userDto.UserFile);
            return await _accountService.UpdateUser(user, userDto);
        }

        public async Task UpdateUser(User user, CancellationToken cancellation)
        {
            await _userManager.UpdateAsync(user);

        }

        public async Task<bool> SeedAdminData()
        {

            //    #region AdminSeed

            //    //var adminRole = await _rolemanager.CreateAsync(new IdentityRole<int>("admin"));
            //    //var x = await _userManager.CreateAsync(new User() { UserName = "test", Email = "test.test@yahoo.com" , CreatedAt=DateTime.UtcNow}, "P@rni@n78");

            //    ////await _userManager.CreateAsync(new User("te"));
            //    //var test = await _userManager.FindByNameAsync("test");
            //    //if (test != null)
            //    //{
            //    //    await _userManager.AddToRoleAsync(test, "admin");
            //    //    return true;
            //    //}
            //    //return false;
            //    #endregion

            //    #region SeedCustomers
            //    //var addCustomerRole = await _rolemanager.CreateAsync(new IdentityRole<int>("customer"));
            //    //var addCustomer = await _userManager.CreateAsync(new User() { CreatedAt = DateTime.UtcNow, FirstName = "parnian", LastName = "Rafie", UserName = "pari", Email = "pari.pari@yahoo.com" }, "P@rni@n78");
            //    //var deletedCustomer = await _userManager.CreateAsync(new User() { CreatedAt = DateTime.UtcNow, FirstName = "zarnian", LastName = "zafie", IsDeleted = true, DeletedAt = DateTime.UtcNow, DeleteComment = "ziad harf mizad", UserName = "zari", Email = "zari.pari@yahoo.com" }, "P@rni@n78");
            //    //var acceptedCustomer = await _userManager.CreateAsync(new User() { CreatedAt = DateTime.UtcNow, IsActive = true, ActivatedAt = DateTime.UtcNow, FirstName = "xarnian", LastName = "xafie", UserName = "xari", Email = "xari.pari@yahoo.com" }, "P@rni@n78");
            //    //if (addCustomerRole.Succeeded)
            //    //{
            //    //    var customer = await _userManager.FindByNameAsync("pari");
            //    //    if (customer != null)
            //    //    {
            //    //        await _userManager.AddToRoleAsync(customer, "customer");
            //    //    }
            //    //    var customer2 = await _userManager.FindByNameAsync("zari");
            //    //    if (customer2 != null)
            //    //    {
            //    //        await _userManager.AddToRoleAsync(customer2, "customer");
            //    //    }
            //    //    var customer3 = await _userManager.FindByNameAsync("xari");
            //    //    if (customer3 != null)
            //    //    {
            //    //        await _userManager.AddToRoleAsync(customer3, "customer");
            //    //    }
            //    //    return true;

            //    //}
            //    //return false;
            //    #endregion
            //    #region SeedSeller
            //var addsellerRole = await _rolemanager.CreateAsync(new IdentityRole<int>("seller"));
            //var addSeller = await _userManager.CreateAsync(new User() { CreatedAt = DateTime.UtcNow, FirstName = "par", LastName = "Ra", UserName = "paria", Email = "par.paria@yahoo.com" }, "P@rni@n78");
            //var deletedSeller = await _userManager.CreateAsync(new User() { CreatedAt = DateTime.UtcNow, FirstName = "zar", LastName = "za", IsDeleted = true, DeletedAt = DateTime.UtcNow, DeleteComment = "ziad harf mizad", UserName = "zaria", Email = "zar.zaria@yahoo.com" }, "P@rni@n78");
            //var acceptedSeller = await _userManager.CreateAsync(new User() { CreatedAt = DateTime.UtcNow, IsActive = true, ActivatedAt = DateTime.UtcNow, FirstName = "xar", LastName = "xa", UserName = "xaria", Email = "xar.xaria@yahoo.com" }, "P@rni@n78");
            var createSeller = await _userManager.CreateAsync(new User() { CreatedAt = DateTime.UtcNow, FirstName = "shaian", LastName = "shayani", UserName = "shani", Email = "shan.shani@yahoo.com" ,FilePathSource="shani.jpg"}, "P@rni@n78");
            //if (addsellerRole.Succeeded)
            //{
                var seller = await _userManager.FindByNameAsync("shani");
                if (seller != null)
                {
                    await _userManager.AddToRoleAsync(seller, "seller");
                }
                //var seller2 = await _userManager.FindByNameAsync("zaria");
                //if (seller2 != null)
                //{
                //    await _userManager.AddToRoleAsync(seller2, "seller");
                //}
                //var seller3 = await _userManager.FindByNameAsync("xaria");
                //if (seller3 != null)
                //{
                //    await _userManager.AddToRoleAsync(seller3, "seller");
                //}
                return true;

            //}
            //return false;
            //    #endregion

        }


        
        #endregion
    }
}

