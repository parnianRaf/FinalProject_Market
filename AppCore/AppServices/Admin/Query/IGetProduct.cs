using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Admin.Query
{
    public interface IGetProduct
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }



}

