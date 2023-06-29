using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Seller.Command
{
    public interface IDeleteAuction
    {
        Task Execute(int id, CancellationToken cancellation);
    }





}

