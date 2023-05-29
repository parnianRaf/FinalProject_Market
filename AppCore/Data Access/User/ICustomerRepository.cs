using AppCore.DtoModels.Customer;
using Microsoft.AspNetCore.Identity;

namespace Repositories.UserRepository
{
    public interface ICustomerRepository
    {
        Task<IdentityResult> AddCustomer(AddCustomerDto customerDto, CancellationToken cancellation);
        Task<bool> DeleteCustomer(int id, CancellationToken cancellationToken);
        Task<List<DetailCustomerDto>> GetAllCustomers(CancellationToken cancellationToken);
        Task<EditCustomerDto> GetUser(int id, CancellationToken cancellation);
        Task<FullDetailCustomerDto> GetCustomerProfile(int id, CancellationToken cancellation);
        Task<SignInResult> LogIn(LogInCustomerDto customerDto, CancellationToken cancellation);
        Task LogOut(CancellationToken cancellation);
        Task<bool> UpdateCustomer(EditCustomerDto customerDto, CancellationToken cancellation);
    }
}