using System;
using AppCore.AppServices.Admin_.Query;
using Repositories.Repository.ProductRepository;

namespace AppService.Admin.Queries
{
	public class GetCommissionPaidBySeller: IGetCommissionPaidBySeller
    {
        #region field
        private readonly IDirectOrderRepository _orderRepository;
        #endregion

        #region ctor
        public GetCommissionPaidBySeller(IDirectOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        #endregion

        #region Implemnetation
        public async Task<decimal> Execute(int sellerId, CancellationToken cancellation)
        {
            return await _orderRepository.CommisionPaidBySellerDirectOredr(sellerId, cancellation);
        }
        #endregion
    }
}

