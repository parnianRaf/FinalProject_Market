using AppCore.DtoModels.Customer;
using AppCore.DtoModels.Seller;

namespace Repositories.UserRepository
{
    public interface ISellerRepository
    {
        Task<bool> AchieveMedal(int sellerId, CancellationToken cancellationToken);
        Task<bool> AddSeller(AddSelllerDto sellerDto, CancellationToken cancellation);
        Task<bool> DeleteSeller(int id, CancellationToken cancellationToken);
        Task<FullDetailSellerDto> GetSellerProfile(int id, CancellationToken cancellation);
        Task<List<DetailSellerDto>> GetAllSellers(CancellationToken cancellationToken);
        Task<bool> LogIn(LogInSellerDto entity, CancellationToken cancellation);
        Task LogOut(CancellationToken cancellation);
        Task<EditSellerDto> UpdateGetSeller(int id, CancellationToken cancellation);
        Task<bool> UpdateSeller(EditSellerDto sellerDto, CancellationToken cancellation);
    }
}