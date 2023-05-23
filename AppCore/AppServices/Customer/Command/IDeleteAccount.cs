using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Customer.Command
{
    public interface IDeleteAccount
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }





}

