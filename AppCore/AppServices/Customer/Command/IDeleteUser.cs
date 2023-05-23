using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Customer.Command
{
    public interface IDeleteUser
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }

}

