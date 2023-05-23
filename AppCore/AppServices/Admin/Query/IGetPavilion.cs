using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Admin.Query
{
    public interface IGetPavilion
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }



}

