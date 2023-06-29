using AppCore;
using AppCore.DtoModels.Customer;

namespace Repositories.Repository.ProductRepository
{
    public interface ICustomerAdressesRepository
    {
        Task AddAddress(DetailedCustomerAdddressDto adddressDto, CancellationToken cancellation);
        Task<bool> EditCustomerAddress(DetailedCustomerAdddressDto adddressDto, CancellationToken cancellation);
        Task<DetailedCustomerAdddressDto> EditGetCustomerAddress(int id, CancellationToken cancellation);
        Task<List<CustomerAddress>> GetAddresses(int id, CancellationToken cancellation);
        Task<bool> RemovePavilion(int id, CancellationToken cancellation);
        Task<bool> SetMainAddress(int id, CancellationToken cancellationToken);
    }
}