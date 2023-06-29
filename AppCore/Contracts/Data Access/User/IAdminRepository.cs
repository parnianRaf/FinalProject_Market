using AppCore.DtoModels.Admin;
using Microsoft.AspNetCore.Identity;

namespace Repositories.UserRepository
{
    public interface IAdminRepository
    {
        Task<bool> AddAdmin(AddAdminDto adminDto, CancellationToken cancellation);
        Task<bool> DeleteCustomer(int id, CancellationToken cancellationToken);
        Task<List<DetailAdminDto>> GetAllAdmins(CancellationToken cancellationToken);
        Task<SignInResult> LogIn(LogInAdminDto entity, CancellationToken cancellation);
        Task LogOut(CancellationToken cancellation);
        Task<bool> SeedAdminData();
        Task<bool> UpdateCustomer(EditAdminDto adminDto, CancellationToken cancellation);
        Task<EditAdminDto> UpdateGetCustomer(int id, CancellationToken cancellation);
    }
}