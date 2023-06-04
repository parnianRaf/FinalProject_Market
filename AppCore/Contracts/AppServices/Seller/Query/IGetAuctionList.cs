using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Seller.Command
{
    public interface IGetAuctionList
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }





}

