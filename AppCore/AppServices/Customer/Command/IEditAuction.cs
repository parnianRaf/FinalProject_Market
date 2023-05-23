using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Seller.Command
{
    public interface IEditAuction
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }





}

