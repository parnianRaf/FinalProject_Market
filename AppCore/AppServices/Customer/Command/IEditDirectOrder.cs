using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Customer.Command
{
    public interface IEditDirectOrder
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }




}

