using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Admin.Query
{
    public interface IGetCategoryBasedSeller
    {
        Task Execute(int sellerId, CancellationToken cancellation);
    }




}

