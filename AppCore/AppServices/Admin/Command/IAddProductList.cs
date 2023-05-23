using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Admin.Command
{
    public interface IAddProductList
    {
        Task Execute(int SellerId, CancellationToken cancellation);
    }



}

