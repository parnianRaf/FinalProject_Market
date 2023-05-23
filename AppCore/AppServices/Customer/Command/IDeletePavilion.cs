using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Seller.Command
{
    public interface IDeletePavilion
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }





}

