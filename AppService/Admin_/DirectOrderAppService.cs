using System;
using AppCore;
using AppCore.Contracts.Services;
using AppCore.DtoModels.Auction;
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

        #endregion

        #region ctor
        public DirectOrderAppService(IDirectOrderService directOrderService,
            IIdGeneratorService idGenerator, IProductAppService productAppService, IAccountAppServices account)
        {
            _directOrderService = directOrderService;
            _idGenerator = idGenerator;
            _productAppService = productAppService;
            _account = account;
        }
        #endregion

        #region Implementation
        public async Task<bool> AddToCart(int productId, CancellationToken cancellation)
        {
            User user = await _account.GetUser<User>(cancellation) ?? new User();
            Product product = await _productAppService.GetEntityProduct(productId, cancellation) ?? new Product();
            if (!_directOrderService.IsExistCurrentUnPaidOrder(user))
            {
                if (product.IsActive)
                {
                    await AddOrder(product, cancellation);
                    return true;
                }
            }
            DirectOrder directOrder = _directOrderService.GetUnPaidDirectOrder(user);
            if (_directOrderService.IsAllowed(product, directOrder))
            {
                await _directOrderService.AddProductToOrderList(product, directOrder, cancellation);
                return true;
            }
            return false;
        }

        public async Task AddOrder(Product product,CancellationToken cancellation)
        {
            int orderId = _idGenerator.Execute<DetailedDirctOrderDto>(await GetAllDirectOrder(cancellation));
            User customer = await _account.GetUser<User>(cancellation);
            await _directOrderService.AddOrder(orderId, customer, product, cancellation);
        }

        public async Task<List<DetailedDirctOrderDto>> GetAllDirectOrder(CancellationToken cancellation)
        {
            return await _directOrderService.GetAllDirectOrder(cancellation);
        }

        public async Task<EditDirectOrderDto> GetDirectOrder(int id, CancellationToken cancellation)
        {
            return await _directOrderService.GetDirectOrder(id, cancellation);
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

