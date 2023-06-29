using AppCore.DtoModels;

namespace Service
{
    public interface IPavilionService
    {
        Task<List<PavilionDtoModel>> GetSellerPavilions(int sellerId, CancellationToken cancellation);
        Task<PavilionDtoModel> GetPavilion(int id, CancellationToken cancellation);
    }
}