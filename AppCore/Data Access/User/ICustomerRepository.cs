using AppCore.DtoModels.Customer;

namespace Repositories.UserRepository
{
    public interface ICustomerRepository
    {
        Task<bool> AddCustomer(AddCustomerDto customerDto, CancellationToken cancellation);
        Task<bool> DeleteCustomer(int id, CancellationToken cancellationToken);
        Task<List<DetailCustomerDto>> GetAllCustomers(CancellationToken cancellationToken);
        Task<bool> UpdateCustomer(EditCustomerDto customerDto, CancellationToken cancellation);
        Task<EditCustomerDto> UpdateGetCustomer(int id, CancellationToken cancellation);
    }
}