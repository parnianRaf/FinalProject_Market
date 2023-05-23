using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Seller.Command
{
    public interface IEditPavilion
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }





}

