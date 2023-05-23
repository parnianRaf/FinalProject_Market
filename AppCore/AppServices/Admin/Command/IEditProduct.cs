using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Admin.Command
{
    public interface IEditProduct
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }



}

