using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Customer.Query
{
    public interface IGetCategoriesList
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }





}

