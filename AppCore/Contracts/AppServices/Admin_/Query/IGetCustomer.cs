using AppCore.DtoModels.Customer;
using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Admin.Query
{
    public interface IGetCustomer
    {
        Task<FullDetailCustomerDto> Execute(int id,CancellationToken cancellation);
    }

}

