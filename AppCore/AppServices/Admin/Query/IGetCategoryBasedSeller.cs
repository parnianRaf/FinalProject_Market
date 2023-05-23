using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Admin.Query
{
    public interface IGetCategoryBasedSeller
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }




}

