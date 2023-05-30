using AppCore.DtoModels;
using AppCore.DtoModels.Customer;
using AppCore.DtoModels.Product;
using AppCore.DtoModels.Seller;
using Microsoft.AspNetCore.Identity;

namespace AppCore.AppServices.Admin.Command
{
    public interface IEditSeller
    {
        Task<bool> Execute(EditProductDto productDto, CancellationToken cancellation);

    }



}

