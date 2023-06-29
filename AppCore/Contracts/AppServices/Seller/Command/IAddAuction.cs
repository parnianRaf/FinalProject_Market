using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Seller.Command
{
    public interface IAddAuction
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }





}

