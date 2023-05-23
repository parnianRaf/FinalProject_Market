using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Seller.Command
{
    public interface ILogIn
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }

}

