using System;
using AppCore;
using AppCore.DtoModels.Seller;
using ExtensionMethods;

namespace Service;

public class SellerStatusService : ISellerStatusService
{
    #region Implemnetation
    public async Task<SellerOverViewDto> SellerOverView(User user)
    {
        SellerOverViewDto sellerOverViewDto = new()
        {
            FullName = user.FullNameToString(),
            HasMedal = user.HasMedal,
            CompletedAuctionNumber = user.Products.Select(p => p.Auction.IsFinished).Count(),
            CompletedOrderNumber = user.Products.Select(p => p.DirectOrder.IsPaid).Count()
        };
        return sellerOverViewDto;
    }
    #endregion
}


