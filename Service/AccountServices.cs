using AppCore;
using AppCore.DtoModels.User;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;


namespace Service;
public class AccountServices : IAccountServices
{
    #region field
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly RoleManager<IdentityRole<int>> _rolemanager;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;
    #endregion

    #region ctor
    public AccountServices(UserManager<User> userManager
        , SignInManager<User> signInManager,
        RoleManager<IdentityRole<int>> rolemanager
        , IMapper mapper,
        IHttpContextAccessor httpContextAccessor)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _rolemanager = rolemanager;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;

    }
    #endregion

    public int GetCurrentUser()
    {
        string id = _userManager.GetUserId(_httpContextAccessor.HttpContext.User) ?? "0";
        return int.Parse(id);
    }

    public bool HasMedal(User user)
    {
        return user.HasMedal;
    }

    //public bool HasMedalCondition(User user)
    //{
    //    medal.
    //}
    public void GetMedal(User user)
    {

    }

    public async Task<IEnumerable<IdentityError>> CreateUser(User user, string password)
    {
        IdentityResult createResult=await _userManager.CreateAsync(user, password);
        return createResult.Errors;
    }

    public async Task<bool> IsRoleExist(string role)
    {
        return await _rolemanager.RoleExistsAsync(role);
    }

    public async Task<IEnumerable<IdentityError>> AddToRole(User user, string role)
    {
        IdentityResult roleResult = await _userManager.AddToRoleAsync(user, role);
        return roleResult.Errors;
    }

    public async Task SetCreateField(User user)
    {
        string id= _userManager.GetUserId(_httpContextAccessor.HttpContext.User) ?? user.Id.ToString();
        user.CreatedBy = int.Parse(id);
        user.CreatedAt = DateTime.UtcNow;
        await _userManager.UpdateAsync(user);
    }

    public async Task<User> GetUser(LogInUser userDto)
    {
        User user= await _userManager.FindByNameAsync(userDto.UserName)?? new User();
        return user;
    }

    public async Task<User> GetUser(int id)
    {
        User user = await _userManager.FindByIdAsync(id.ToString()) ?? new User();
        return user;
    }

    public async Task<bool> IsInRole(User user,string role)
    {
        return await _userManager.IsInRoleAsync(user,role);
    }

    public async Task<bool> SignIn(User user,string password,bool IsRememberMe)
    {
        SignInResult logInResult=await _signInManager.PasswordSignInAsync(user, password, IsRememberMe,false);
        return logInResult.Succeeded ? true : false;
    }

    public async Task SignOut()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task<List<User>> GetAllUserRoleBAsed(string role)
    {
        IEnumerable<User> users = new List<User>();
        users = await _userManager.GetUsersInRoleAsync(role);
        return users.ToList();
    }

    public async Task<List<IdentityError>> DeleteUser(User user)
    {
        user.IsActive = false;
        user.IsDeleted = true;
        user.DeletedAt = DateTime.Now;
        string id = _userManager.GetUserId(_httpContextAccessor.HttpContext.User) ?? user.Id.ToString();
        user.DeletedBy = int.Parse(id);
        IdentityResult delteResult = await _userManager.UpdateAsync(user);
        return delteResult.Errors.ToList();
    }

    public async Task<bool> UpdateUser(User user, EditUserDto userDto)
    {
        bool result = false;
        user.FirstName = userDto.FirstName;
        user.LastName = userDto.LastName;
        user.Email = userDto.Email;
        user.PhoneNumber = userDto.PhoneNumber;
        user.NationalityCode = userDto.NationalityCode;
        string id =_userManager.GetUserId(_httpContextAccessor.HttpContext.User) ?? user.Id.ToString();
        user.ModifiedBy = int.Parse(id);
        var updateResult=await _userManager.UpdateAsync(user);
        if (updateResult.Succeeded)
        {
            return !result;
        }
        return result;
    }

    public async Task<bool> ActiveUser(User user)
    {
        bool result = false;
        user.IsActive = true;
        user.IsDeleted = false;
        user.ActivatedAt = DateTime.Now;
        string userId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User) ?? user.Id.ToString();
        user.ActivatedAt = DateTime.UtcNow;
        user.ModifiedBy = int.Parse(userId);
        var updateResult = await _userManager.UpdateAsync(user);
        if (updateResult.Succeeded)
        {
            return !result;
        }
        return result;
    }

}

