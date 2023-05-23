using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Customer.Query
{
    public interface IGetSellerList
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }




}

