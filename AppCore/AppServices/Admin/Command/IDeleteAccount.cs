using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Admin.Command
{
    public interface IDeleteAccount
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }

}

