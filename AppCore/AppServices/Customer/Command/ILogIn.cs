using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Customer.Command
{
    public interface ILogIn
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }





}

