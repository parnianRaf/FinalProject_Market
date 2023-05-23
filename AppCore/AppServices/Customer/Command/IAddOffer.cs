using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Customer.Command
{
    public interface IAddOffer
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }


}

