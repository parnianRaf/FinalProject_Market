using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Admin.Command
{
    public interface IDeleteProduct
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }



}

