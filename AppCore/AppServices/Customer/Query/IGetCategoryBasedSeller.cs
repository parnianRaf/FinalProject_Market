using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Customer.Query
{
    public interface IGetCategoryBasedSeller
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }




}

