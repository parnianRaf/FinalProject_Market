using AppCore;
using AppCore.DtoModels.Comment;
using AppCore.DtoModels.DirectOrder;

namespace AppService.Admin_
{
    public interface IDirectOrderAppService
    {
        Task<List<DetailedDirctOrderDto>> GetAllDirectOrder(CancellationToken cancellation);
        Task<EditDirectOrderDto> GetCurrentDirectOrder(CancellationToken cancellation);
        Task<DirectOrderCartDto> GetDirectOrderCart(int orderId, CancellationToken cancellation);
        Task<EditDirectOrderDto> GetDirectOrder(int id, CancellationToken cancellation);
        Task<List<DetailedDirctOrderDto>> GetAllCurrentUserPaidDirectOrders(CancellationToken cancellation);
        Task<List<DetailedDirctOrderDto>> GetAllPaidDirectOrders(User user, CancellationToken cancellation);
        Task<DirectOrderCartDto> SubmitOrder(int id, CancellationToken cancellation);
        Task<List<CommentOrderDto>> GetSellerComments(CancellationToken cancellation);
        Task AddComment(AddCommentDto commentDto, CancellationToken cancellation);
        Task<bool> AcceptComment(int orderId, CancellationToken cancellation);
        Task<bool> RejectComment(int orderId, CancellationToken cancellation);
        Task<bool> AddToCart(int productId, CancellationToken cancellation);
    }
}