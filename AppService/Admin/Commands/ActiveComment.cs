//using System;
//using AppCore.AppServices.Admin_.Command;
//using Repositories.Repository.ProductRepository;
//using Repositories.UserRepository;

//namespace AppService.Admin.Commands
//{
//    public class ActiveComment : IActiveComment
//    {
//        #region field
//        private readonly IDirectOrderRepository _orderRepository;
//        #endregion

//        #region ctor
//        public ActiveComment(IDirectOrderRepository orderRepository)
//        {
//            _orderRepository = orderRepository;
//        }
//        #endregion

//        #region Implementation
//        public async Task<bool> Execute(int id, CancellationToken cancellation)
//        {
//            return await _orderRepository.AcceptComment(id, cancellation);
//        }
//        #endregion
//    }
//}

