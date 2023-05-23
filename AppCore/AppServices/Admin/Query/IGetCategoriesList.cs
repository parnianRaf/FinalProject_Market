using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Admin.Query
{
    public interface IGetCategoriesList
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }





}

