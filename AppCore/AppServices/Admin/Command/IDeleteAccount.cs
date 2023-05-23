using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Admin.Command
{
    public interface IDeleteAccount
    {
        Task Execute(int id, CancellationToken cancellation);
    }

}

