using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Admin.Command
{
    public interface IAddUserList
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }



}

