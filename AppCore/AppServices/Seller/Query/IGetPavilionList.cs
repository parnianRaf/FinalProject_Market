using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Seller.Command
{
    public interface IGetPavilionList
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }





}

