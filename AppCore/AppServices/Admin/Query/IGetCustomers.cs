using AppCore.DtoModels.Customer;
using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Admin.Query
{
    public interface IGetCustomers
    {
        Task<List<DetailCustomerDto>> Execute(CancellationToken cancellation);
    }

}

