using AppCore;
using AppCore.DtoModels.DirectOrder;

namespace Service
{
    public interface IDirectOrderService
    {
        Task<bool> AcceptComment(int orderId, CancellationToken cancellation);
        Task AddOrder(int orderId, User customer, Product product, CancellationToken cancellation);
        Task<List<DetailedDirctOrderDto>> GetAllDirectOrder(CancellationToken cancellation);
        Task<EditDirectOrderDto> GetDirectOrder(int id, CancellationToken cancellation);
        Task<bool> RejectComment(int orderId, CancellationToken cancellation);
        bool IsExistCurrentUnPaidOrder(User user);
        Task<DirectOrder> GetEntityDirectOrder(int id, CancellationToken cancellation);
        DirectOrder GetUnPaidDirectOrder(User customer);
        bool IsAllowed(Product product, DirectOrder order);
        Task AddProductToOrderList(Product product, DirectOrder order, CancellationToken cancellation);
    }
}