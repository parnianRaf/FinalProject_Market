using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Admin.Query
{
    public interface IGetProfile
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }





}

