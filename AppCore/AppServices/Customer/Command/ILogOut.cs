using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Customer.Command
{
    public interface ILogOut
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }

}

