using AppCore.DtoModels;

namespace AppService.Admin_
{
    public interface IPavilionAppService
    {
        Task<List<PavilionDtoModel>> GetSellerPavilions(CancellationToken cancellation);


        Task<bool> EditPavilion(PavilionDtoModel pavilionDto, CancellationToken cancellation);
        Task<bool> RemovePavilion(int id, CancellationToken cancellation);
        Task<PavilionDtoModel> GetPavilion(int id, CancellationToken cancellation);
        Task<bool> ActiveProduct(int id, CancellationToken cancellation);
    }
}