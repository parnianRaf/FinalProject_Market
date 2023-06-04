using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Seller.Command
{
    public interface IDeleteAccount
    {
        Task Execute(int id, CancellationToken cancellation);
    }





}

