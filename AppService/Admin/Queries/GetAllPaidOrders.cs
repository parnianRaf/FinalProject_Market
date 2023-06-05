//using System;
//using AppCore.AppServices.Admin_.Query;
//using AppCore.DtoModels.DirectOrder;
//using Repositories.Repository.ProductRepository;

//namespace AppService.Admin.Queries
//{
//	public class GetAllPaidOrders: IGetAllPaidOrders
//    {
//        #region field
//        private readonly IDirectOrderRepository _directOrder;
//        #endregion

//        #region ctor
//        public GetAllPaidOrders(IDirectOrderRepository directOrder)
//        {
//            _directOrder = directOrder;
//        }
//        #endregion

//        #region Implementation
//        public async Task<List<DetailedDirctOrderDto>> Execute(CancellationToken cancellation)
//        {
//            return await _directOrder.GetAllPaidOrders(cancellation);
//        }
//        #endregion
//    }
//}

