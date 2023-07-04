using AppCore;
using AppCore.DtoModels.DirectOrder;

namespace Service
{
    public interface IDirectOrderService
    {
        Task<bool> AcceptComment(int orderId, CancellationToken cancellation);
        Task<DirectOrder> AddOrder(int orderId, User customer, Product product, CancellationToken cancellation);
        Task<List<DetailedDirctOrderDto>> GetAllDirectOrder(CancellationToken cancellation);
        Task<EditDirectOrderDto> GetDirectOrder(int id, CancellationToken cancellation);
        Task<bool> RejectComment(int orderId, CancellationToken cancellation);
        Task<List<CommentOrderDto>> GetSellerComments(User seller, CancellationToken cancellation);
        Task<DirectOrderCartDto> GetDirectOrderCart(int orderId, CancellationToken cancellation);
        Task<DirectOrder> GetEntityDirectOrder(int id, CancellationToken cancellation);
        Task<DirectOrder> GetUnPaidDirectOrder(int customerId, CancellationToken cancellation);
        Task SubmitOrder(DirectOrder order, CancellationToken cancellation);
        Task SubmitComment(DirectOrder order, string comment, CancellationToken cancellation);
        bool IsAllowed(Product product, DirectOrder order);
        Task AddProductToOrderList(User user, Product product, DirectOrder order, CancellationToken cancellation);
    }
}