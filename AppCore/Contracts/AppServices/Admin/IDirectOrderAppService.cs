using AppCore.DtoModels.DirectOrder;

namespace AppService.Admin_
{
    public interface IDirectOrderAppService
    {
        Task<List<DetailedDirctOrderDto>> GetAllDirectOrder(CancellationToken cancellation);
        Task<EditDirectOrderDto> GetDirectOrder(int id, CancellationToken cancellation);
    }
}