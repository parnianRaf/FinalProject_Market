using AppCore;
using AppCore.DtoModels.DirectOrder;

namespace Repositories.Repository.ProductRepository
{
    public interface IDirectOrderRepository
    {
        Task<bool> AcceptComment(int orderId, CancellationToken cancellation);
        Task<bool> AddCommentByCustomer(int orderId, int customerId, string comment, CancellationToken cancellation);
        Task<DirectOrder> AddDirectOrder(int orderId, User customer, Product product, CancellationToken cancellation);
        Task UpdateSubmitOrder(DirectOrder order, CancellationToken cancellation);
        Task<bool> EditAuction(EditDirectOrderDto orderDto, CancellationToken cancellation);
        Task<List<DetailedDirctOrderDto>> GetAllPaidOrders(CancellationToken cancellation);
        Task<bool> RejectComment(int orderId, CancellationToken cancellation);
        Task<decimal> CommisionPaidBySellerDirectOredr(int sellerId, CancellationToken cancellation);
        Task<bool> RemoveAuction(int id, CancellationToken cancellation);
        Task<T> GetOrer<T>(int id, CancellationToken cancellation);
        Task<List<CommentOrderDto>> GetSellerComments(User seller, CancellationToken cancellation);
        Task<DirectOrderCartDto> GetCart(int orderId, CancellationToken cancellation);
        Task<DirectOrder> GetCurrentCustomerDirectOrders(int customerId, CancellationToken cancellation);
        Task<List<DirectOrder>> GetPaidCurrentCustomerDirectOrders(int customerId, CancellationToken cancellation);
        Task<List<DetailedDirctOrderDto>> GetDetailedPaidCurrentCustomerDirectOrders(int customerId, CancellationToken cancellation);
        Task<List<DirectOrder>> GetSuccededSellerDirectOrder(int sellerId, CancellationToken cancellation);
        Task<List<DetailedDirctOrderDto>> GetSuccededDetailedSellerDirectOrder(int sellerId, CancellationToken cancellation);
        Task AddProductToOrderList(User user, Product product, DirectOrder order, decimal productPrice, CancellationToken cancellation);
    }
}