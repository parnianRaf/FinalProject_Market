using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Admin.Command
{
    public interface IRegister
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }





}

