using AppCore;
using AppCore.DtoModels.User;
using Microsoft.AspNetCore.Identity;

namespace Service
{
    public interface IAccountServices
    {
        Task<IEnumerable<IdentityError>> CreateUser(User user, string password);
        Task<bool> IsRoleExist(string role);
        Task<IEnumerable<IdentityError>> AddToRole(User user, string role);
        Task SetCreateField(User user);
        Task<User> GetUser(LogInUser userDto);
        Task<User> GetUser(int id);
        Task<bool> IsInRole(User user, string role);
        Task<bool> SignIn(User user, string password, bool IsRememberMe);
        Task SignOut();
        Task<List<User>> GetAllUserRoleBAsed(string role);
        Task<List<IdentityError>> DeleteUser(User user);
        Task<bool> UpdateUser(User user, EditUserDto userDto);
        Task<bool> ActiveUser(User user);
        int GetCurrentUser();
    }
}