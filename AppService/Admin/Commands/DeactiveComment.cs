using System;
using AppCore.AppServices.Admin_.Command;
using Repositories.Repository.ProductRepository;
using Repositories.UserRepository;

namespace AppService.Admin.Commands
{
    public class DeactiveComment : IDeactiveComment
    {
        #region field
        private readonly IDirectOrderRepository _orderRepository;
        #endregion

        #region ctor
        public DeactiveComment(IDirectOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        #endregion

        #region Implementation
        public async Task<bool> Execute(int id, CancellationToken cancellation)
        {
            return await _orderRepository.RejectComment(id, cancellation);
        }
        #endregion
    }
}

