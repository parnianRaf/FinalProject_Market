using AppCore;
using AppCore.DtoModels.User;

namespace AppService.Admin_.Command
{
    public interface IAccountAppServices
    {
        Task<bool> AddToAdmin(User user, CancellationToken cancellation);
        Task<bool> AddToCustomer(User user, CancellationToken cancellation);
        Task<bool> AddToSeller(User user, CancellationToken cancellation);
        Task<bool> DeleteUser(int id, CancellationToken cancellationToken);
        Task<List<T>> GetAllCustomers<T>(CancellationToken cancellationToken);
        Task<List<T>> GetAllSellers<T>(CancellationToken cancellationToken);
        Task<T> GetUser<T>(int id, CancellationToken cancellation);
        Task<T> GetUserProfile<T>(int id, CancellationToken cancellation);
        Task<int> LogIn(int id, LogInUser user, CancellationToken cancellation);
        Task LogOut(CancellationToken cancellation);
        Task<string> Register(int id, AddUserDto userDto);
        Task<bool> UpdateUser(EditUserDto userDto, CancellationToken cancellation);
        Task<bool> SeedAdminData();
    }
}