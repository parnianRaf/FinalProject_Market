using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Customer.Command
{
    public interface IDeleteDirectOrder
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }




}

