using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Seller.Command
{
    public interface IGetProductList
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }




}

