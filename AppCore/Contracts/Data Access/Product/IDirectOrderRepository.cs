using AppCore;
using AppCore.DtoModels.DirectOrder;

namespace Repositories.Repository.ProductRepository
{
    public interface IDirectOrderRepository
    {
        Task<bool> AcceptComment(int orderId, CancellationToken cancellation);
        Task<bool> AddCommentByCustomer(int orderId, int customerId, string comment, CancellationToken cancellation);
        Task AddDirectOrder(int orderId, User customer, Product product, CancellationToken cancellation);
        Task<bool> EditAuction(EditDirectOrderDto orderDto, CancellationToken cancellation);
        Task<List<DetailedDirctOrderDto>> GetAllPaidOrders(CancellationToken cancellation);
        Task<bool> RejectComment(int orderId, CancellationToken cancellation);
        Task<decimal> CommisionPaidBySellerDirectOredr(int sellerId, CancellationToken cancellation);
        Task<bool> RemoveAuction(int id, CancellationToken cancellation);
        Task<T> GetOrer<T>(int id, CancellationToken cancellation);
        Task AddProductToOrderList(Product product, DirectOrder order, decimal productPrice, CancellationToken cancellation);
    }
}