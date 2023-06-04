using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Seller.Command
{
    public interface IGetCategoriesList
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }





}

