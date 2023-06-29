using AppCore.DtoModels.Auction;

namespace AppCore.AppServices.Seller.Command
{
    public interface ILogOut
    {
        Task Execute(AddAuctionDto auctionDto, CancellationToken cancellation);
    }




}

