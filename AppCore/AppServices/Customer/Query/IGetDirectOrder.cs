using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Customer.Query
{
    public interface IGetDirectOrder
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }




}

