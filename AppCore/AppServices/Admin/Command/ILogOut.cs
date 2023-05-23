using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Admin.Command
{
    public interface ILogOut
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }

}

