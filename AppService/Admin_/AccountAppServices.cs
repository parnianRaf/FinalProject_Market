using System;
using AppCore;
using AppCore.DtoModels.User;
using AppSqlDataBase;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Runtime.Serialization;
using Serilog;

namespace AppService.Admin_.Command
{
    public class AccountAppServices : IAccountAppServices
    {
        #region field
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _rolemanager;
        private readonly IMapper _mapper;
        private readonly MarketContext context;
        #endregion

        #region ctor
        public AccountAppServices(UserManager<User> userManager
            , SignInManager<User> signInManager,
            RoleManager<IdentityRole<int>> rolemanager
            , IMapper mapper, MarketContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _rolemanager = rolemanager;
            _mapper = mapper;
            this.context = context;
        }
        #endregion

        #region Implementation
        public async Task<string> Register(int id, AddUserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var addResult = await _userManager.CreateAsync(user, userDto.Password);
            switch (id)
            {
                case 1:
                    var addRoleResult = await _userManager.AddToRoleAsync(user, "customer");
                    if (addRoleResult.Succeeded)
                    {
                        return "1";
                    }
                    break;


                case 2:
                    addRoleResult = await _userManager.AddToRoleAsync(user, "Seller");
                    if (addRoleResult.Succeeded)
                    {
                        return "2";
                    }
                    break;

            }
            return "0";
        }

        public async Task<bool> AddToAdmin(User user, CancellationToken cancellation)
        {
            var addRoleResult = await _userManager.AddToRoleAsync(user, "admin");
            if (addRoleResult.Succeeded)
            {
                return true;
            }
            return false;

        }

        public async Task<bool> AddToCustomer(User user, CancellationToken cancellation)
        {
            var addRoleResult = await _userManager.AddToRoleAsync(user, "customer");
            if (addRoleResult.Succeeded)
            {
                return true;
            }
            return false;

        }

        public async Task<bool> AddToSeller(User user, CancellationToken cancellation)
        {
            var addRoleResult = await _userManager.AddToRoleAsync(user, "seller");
            if (addRoleResult.Succeeded)
            {
                return true;
            }
            return false;

        }

        public async Task<int> LogIn(int id, LogInUser user, CancellationToken cancellation)
        {
            User? user1 = await _userManager.FindByNameAsync(user.UserName);
            //if (user1 != null)
            //{
            try
            {
                switch (id)
                {
                    case 1:
                        if (await _userManager.IsInRoleAsync(user1, "customer"))
                        {
                            var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, user.IsRememberMe, false);
                            if (result.Succeeded)
                            {
                                return 1;
                            }
                        }
                        break;
                    case 2:
                        if (await _userManager.IsInRoleAsync(user1, "seller"))
                        {
                            var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, user.IsRememberMe, false);
                            if (result.Succeeded)
                            {
                                return 2;
                            }
                        }
                        break;
                    case 3:
                        if (await _userManager.IsInRoleAsync(user1, "admin"))
                        {
                            var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, user.IsRememberMe, false);
                            if (result.Succeeded)
                            {
                                
                                Log.ForContext("UserName", user1.UserName).Information("{0} has been logged in", user1.UserName);
                                return 3;
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.ForContext("UserName", user.UserName).Error("{0} has the error: {1}", user.UserName,ex);

            }

            //}
            return 0;
        }

        public async Task LogOut(CancellationToken cancellation)
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<List<T>> GetAllCustomers<T>(CancellationToken cancellationToken)
        {
            var result = await (_userManager.GetUsersInRoleAsync("customer"));
            return _mapper.Map<List<T>>(result);
        }

        public async Task<List<T>> GetAllSellers<T>(CancellationToken cancellationToken)
        {
            var result = await _userManager.GetUsersInRoleAsync("seller");
            return _mapper.Map<List<T>>(result);
        }

        public async Task<T> GetUserProfile<T>(int id, CancellationToken cancellation)
        {
            User? user = await _userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                return _mapper.Map<T>(user);
            }

            return (T)FormatterServices.GetUninitializedObject(typeof(T));
        }

        public async Task<bool> DeleteUser(int id, CancellationToken cancellationToken)
        {
            bool result = false;
            User? user = await _userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                user.IsActive = false;
                user.IsDeleted = true;
                user.DeletedAt = DateTime.Now;
                //user.DeleteBy
                var delteResult = await _userManager.UpdateAsync(user);
                if (delteResult.Succeeded)
                {
                    return !result;

                }
            }
            return result;

        }

        public async Task<T> GetUser<T>(int id, CancellationToken cancellation)
        {
            User? user = await _userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                return _mapper.Map<T>(user);
            }
            return (T)FormatterServices.GetUninitializedObject(typeof(T));
        }

        public async Task<bool> UpdateUser(EditUserDto userDto, CancellationToken cancellation)
        {
            User? user = await _userManager.FindByIdAsync(userDto.Id.ToString());
            if (user != null)
            {
                user.FirstName = userDto.FirstName;
                user.LastName = userDto.LastName;
                user.Email = userDto.Email;
                user.PhoneNumber = userDto.PhoneNumber;
                user.NationalityCode = userDto.NationalityCode;
                var res = await _userManager.UpdateAsync(user);
                if (res.Succeeded)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}

