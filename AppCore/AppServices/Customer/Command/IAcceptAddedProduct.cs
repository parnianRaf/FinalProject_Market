using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Customer.Command
{
    public interface IAcceptAddedProduct
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }

}

