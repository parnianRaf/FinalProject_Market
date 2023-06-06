using AppCore.DtoModels.DirectOrder;

namespace AppService.Admin_
{
    public interface IDirectOrderAppService
    {
        Task<List<DetailedDirctOrderDto>> GetAllDirectOrder(CancellationToken cancellation);
        Task<EditDirectOrderDto> GetDirectOrder(int id, CancellationToken cancellation);
        Task<bool> AcceptComment(int orderId, CancellationToken cancellation);
        Task<bool> RejectComment(int orderId, CancellationToken cancellation);
    }
}