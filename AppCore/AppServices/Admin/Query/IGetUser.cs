using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Admin.Query
{
    public interface IGetUser
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }

}

