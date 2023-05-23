using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Customer.Command
{
    public interface IAddDirectOrder
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }




}

