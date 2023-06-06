using System;
using AppCore.DtoModels.Auction;
using AppCore.DtoModels.DirectOrder;
using Repositories.Repository.ProductRepository;

namespace AppService.Admin_
{
    public class DirectOrderAppService : IDirectOrderAppService
    {
        #region field
        private readonly IDirectOrderRepository _directOrderRepository;
        #endregion

        #region ctor
        public DirectOrderAppService(IDirectOrderRepository directOrderRepository)
        {
            _directOrderRepository = directOrderRepository;
        }
        #endregion

        #region Implementation
        public async Task<List<DetailedDirctOrderDto>> GetAllDirectOrder(CancellationToken cancellation)
        {
            return await _directOrderRepository.GetAllPaidOrders(cancellation);
        }

        public async Task<EditDirectOrderDto> GetDirectOrder(int id, CancellationToken cancellation)
        {
            return await _directOrderRepository.GetOrer(id, cancellation);
        }

        public async Task<bool> AcceptComment(int orderId,CancellationToken cancellation)
        {
            return await _directOrderRepository.AcceptComment(orderId, cancellation);
        }

        public async Task<bool> RejectComment(int orderId,CancellationToken cancellation)
        {
            return await _directOrderRepository.RejectComment(orderId, cancellation);
        }
        #endregion
    }
}

