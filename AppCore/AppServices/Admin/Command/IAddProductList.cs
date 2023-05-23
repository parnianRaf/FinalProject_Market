using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Admin.Command
{
    public interface IAddProductList
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }



}

