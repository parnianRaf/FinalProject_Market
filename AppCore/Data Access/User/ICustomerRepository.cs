using AppCore.DtoModels.Customer;

namespace Repositories.UserRepository
{
    public interface ICustomerRepository
    {
        Task<bool> AddCustomer(AddCustomerDto customerDto, CancellationToken cancellation);
        Task<bool> DeleteCustomer(int id, CancellationToken cancellationToken);
        Task<List<DetailCustomerDto>> GetAllCustomers(CancellationToken cancellationToken);
        Task<EditCustomerDto> GetCustomer(int id, CancellationToken cancellation);
        Task<bool> LogIn(LogInCustomerDto customerDto, CancellationToken cancellation);
        Task LogOut(CancellationToken cancellation);
        Task<bool> UpdateCustomer(EditCustomerDto customerDto, CancellationToken cancellation);
    }
}