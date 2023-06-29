using System;
using AppCore;
using AppCore.Contracts.AppServices.Account;
using AppCore.Contracts.Services;
using AppCore.DtoModels.Auction;
using AppCore.DtoModels.Comment;
using AppCore.DtoModels.DirectOrder;
using AppService.Admin_.Command;
using Repositories.Repository.ProductRepository;
using Service;

namespace AppService.Admin_
{
    public class DirectOrderAppService : IDirectOrderAppService
    {
        #region field
        private readonly IDirectOrderService _directOrderService;
        private readonly IProductAppService _productAppService;
        private readonly IIdGeneratorService _idGenerator;
        private readonly IAccountAppServices _account;
        private readonly IMapServices _mapper;
        #endregion

        #region ctor
        public DirectOrderAppService(IDirectOrderService directOrderService,
            IIdGeneratorService idGenerator, IProductAppService productAppService, IAccountAppServices account, IMapServices mapper)
        {
            _directOrderService = directOrderService;
            _idGenerator = idGenerator;
            _productAppService = productAppService;
            _account = account;
            _mapper = mapper;
        }
        #endregion

        #region Implementation
        public async Task<bool> AddToCart(int productId, CancellationToken cancellation)
        {
            User user = await _account.GetUser<User>(cancellation) ?? new User();
            Product product = await _productAppService.GetEntityProduct(productId, cancellation) ?? new Product();
            DirectOrder? order = await _directOrderService.GetUnPaidDirectOrder(user.Id, cancellation);
            if (order.UserId is 0)
            {
                if (product.IsActive)
                {
                    await AddOrder(product, cancellation);
                    await _account.UpdateUser(user, cancellation);
                    return true;
                }
            }
            if (_directOrderService.IsAllowed(product, order))
            {
                await _directOrderService.AddProductToOrderList(user,product, order, cancellation);
                return true;
            }
            return false;
        }

        public async Task<DirectOrder> AddOrder(Product product,CancellationToken cancellation)
        {
            int orderId = _idGenerator.Execute<DetailedDirctOrderDto>(await GetAllDirectOrder(cancellation));
            User customer = await _account.GetUser<User>(cancellation);
            return await _directOrderService.AddOrder(orderId, customer, product, cancellation);
        }

        public async Task<List<DetailedDirctOrderDto>> GetAllDirectOrder(CancellationToken cancellation)
        {
            return await _directOrderService.GetAllDirectOrder(cancellation);
        }

        public async Task<EditDirectOrderDto> GetCurrentDirectOrder(CancellationToken cancellation)
        {
            User user = await _account.GetUser<User>(cancellation) ?? new User();
            EditDirectOrderDto directOrderDto= _mapper.MapOrder(await _directOrderService.GetUnPaidDirectOrder(user.Id,cancellation));
            return directOrderDto;
        }

        public async Task<DirectOrderCartDto> GetDirectOrderCart(int orderId, CancellationToken cancellation)
        {
            return await _directOrderService.GetDirectOrderCart(orderId, cancellation);
        }

        public async Task<EditDirectOrderDto> GetDirectOrder(int id, CancellationToken cancellation)
        {
            return await _directOrderService.GetDirectOrder(id, cancellation);
        }

        public async Task<DirectOrderCartDto> SubmitOrder(int id,CancellationToken cancellation)
        {
            DirectOrder order = await _directOrderService.GetEntityDirectOrder(id,cancellation);
            await _directOrderService.SubmitOrder(order, cancellation);
            return await _directOrderService.GetDirectOrderCart(id, cancellation);
        }

        public async Task AddComment(AddCommentDto commentDto,CancellationToken cancellation)
        {
            DirectOrder order = await _directOrderService.GetEntityDirectOrder(commentDto.OrderId, cancellation);
            await _directOrderService.SubmitComment(order, commentDto.CommentByCostumer, cancellation);
        }

        public async Task<bool> AcceptComment(int orderId,CancellationToken cancellation)
        {
            return await _directOrderService.AcceptComment(orderId, cancellation);
        }

        public async Task<bool> RejectComment(int orderId,CancellationToken cancellation)
        {
            return await _directOrderService.RejectComment(orderId, cancellation);
        }
        #endregion
    }
}

