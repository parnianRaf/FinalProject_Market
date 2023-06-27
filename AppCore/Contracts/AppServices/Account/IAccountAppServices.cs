using AppCore;
using AppCore.DtoModels.Offer;
using AppCore.DtoModels.Seller;
using AppCore.DtoModels.User;
using Microsoft.AspNetCore.Identity;

namespace AppService.Admin_.Command
{
    public interface IAccountAppServices
    {
        Task<bool> ActiveUser(int id, CancellationToken cancellation);
        Task<List<IdentityError>> DeleteUser(int id, CancellationToken cancellationToken);
        Task<List<T>> GetAllUserRoleBased<T>(string role);
        Task<T> GetUser<T>(int id, CancellationToken cancellation);
        Task<T> GetUserProfile<T>(CancellationToken cancellation);
        Task<Tuple<SellerOverViewDto, T>> GetCurrentUserProfile<T>(CancellationToken cancellation);
        Task<bool> LogIn(string role, LogInUser userDto, bool IsRememberMe);
        Task LogOut(CancellationToken cancellation);
        Task<IEnumerable<IdentityError>> Register(string role, AddUserDto userDto);
        Task<bool> SeedAdminData();
        Task<bool> UpdateUser(EditUserDto userDto, CancellationToken cancellation);
        Task UpdateUser(User user, CancellationToken cancellation);
        Task<T> GetUser<T>(CancellationToken cancellation);
        int GetUserId();
    }
}