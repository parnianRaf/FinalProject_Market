using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Customer.Command
{
    public interface IRejectAddedProduct
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }

}

