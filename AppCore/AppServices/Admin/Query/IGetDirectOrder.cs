using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Admin.Query
{
    public interface IGetDirectOrder
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }




}

