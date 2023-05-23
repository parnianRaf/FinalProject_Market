using AppCore.DtoModels.DirectOrder;

namespace Repositories.Repository.ProductRepository
{
    public interface IDirectOrderRepository
    {
        Task<bool> AcceptComment(int orderId, CancellationToken cancellation);
        Task<bool> AddCommentByCustomer(int orderId, int customerId, string comment, CancellationToken cancellation);
        Task AddDirectOrder(AddDirectDto oredrDto, CancellationToken cancellation);
        Task<bool> EditAuction(EditDirectOrderDto orderDto, CancellationToken cancellation);
        Task<EditDirectOrderDto> EditGetOrer(int id, CancellationToken cancellation);
        Task<List<DetailedPaidDirectOrderDto>> GetAllPaidOrders(CancellationToken cancellation, int customerId);
        Task<List<DetailedDirctOrderDto>> GetpaidOrder(int customerId, CancellationToken cancellation);
        Task<bool> RejectComment(int orderId, CancellationToken cancellation);
        Task<bool> RemoveAuction(int id, CancellationToken cancellation);
    }
}