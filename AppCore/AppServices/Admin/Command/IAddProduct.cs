using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Admin.Command
{
    public interface IAddProduct
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }



}

