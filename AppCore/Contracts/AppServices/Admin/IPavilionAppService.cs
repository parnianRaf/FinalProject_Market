using AppCore.DtoModels;

namespace AppService.Admin_
{
    public interface IPavilionAppService
    {
        Task<bool> EditPavilion(PavilionDtoModel pavilionDto, CancellationToken cancellation);
        Task<List<PavilionDtoModel>> GetSellerPavilions(int sellerId, CancellationToken cancellation);
        Task<bool> RemovePavilion(int id, CancellationToken cancellation);
    }
}