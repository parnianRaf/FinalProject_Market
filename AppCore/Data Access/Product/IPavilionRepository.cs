using AppCore;
using AppCore.DtoModels;

namespace Repositories.Repository.ProductRepository
{
    public interface IPavilionRepository
    {
        Task AddPavilion(PavilionDtoModel pavilionDto, CancellationToken cancellation);
        Task<PavilionDtoModel> EditGetPavilion(int id, CancellationToken cancellation);
        Task<bool> EditPavilion(PavilionDtoModel pavilionDto, CancellationToken cancellation);
        Task<List<Pavilion>> GetSellerPavilions(int selerId, CancellationToken cancellation);
        Task<List<Pavilion>> GetPavilions(CancellationToken cancellation);
        Task<bool> RemovePavilion(int id, CancellationToken cancellation);
    }
}