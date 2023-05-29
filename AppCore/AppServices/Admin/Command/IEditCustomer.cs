using AppCore.DtoModels.Customer;
using AppCore.DtoModels.Product;
using Microsoft.AspNetCore.Identity;

namespace AppCore.AppServices.Admin.Command
{
    public interface IEditCustomer
    {
        Task<IdentityResult> Execute(EditCustomerDto customerDto, CancellationToken cancellation);
    }



}

