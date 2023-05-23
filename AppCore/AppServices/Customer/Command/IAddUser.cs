using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Customer.Command
{
    public interface IAddUser
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }

}

