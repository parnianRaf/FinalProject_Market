using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Seller.Command
{
    public interface IAddPavilion
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }





}

