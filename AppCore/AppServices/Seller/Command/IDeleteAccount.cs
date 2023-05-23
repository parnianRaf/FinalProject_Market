using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Seller.Command
{
    public interface IDeleteAccount
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }





}

