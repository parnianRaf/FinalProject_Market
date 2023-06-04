using AppCore.DtoModels.Auction;
using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Seller.Command
{
    public interface IEditAuction
    {
        Task Execute(EditAuctionDto entity, CancellationToken cancellation);
    }





}

