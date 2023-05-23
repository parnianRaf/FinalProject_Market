using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Seller.Command
{
    public interface IDeleteAuction
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }





}

