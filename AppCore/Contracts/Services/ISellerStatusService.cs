using AppCore;
using AppCore.DtoModels.Seller;

namespace Service
{
    public interface ISellerStatusService
    {
        Task<SellerOverViewDto> SellerOverView(User user);
    }
}