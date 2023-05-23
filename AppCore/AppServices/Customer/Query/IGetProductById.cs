using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Seller.Command
{
    public interface IGetProductById
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }




}

