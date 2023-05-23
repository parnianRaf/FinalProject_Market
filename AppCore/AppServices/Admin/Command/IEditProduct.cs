using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Admin.Command
{
    public interface IEditProduct
    {
        Task Execute(EditProductDto productDto, CancellationToken cancellation);
    }



}

