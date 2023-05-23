using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Admin.Command
{
    public interface IEditUser
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }



}

