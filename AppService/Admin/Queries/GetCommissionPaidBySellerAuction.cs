//using System;
//using AppCore.AppServices.Admin_.Query;
//using Repositories.Repository.ProductRepository;

//namespace AppService.Admin.Queries
//{
//	public class GetCommissionPaidBySellerAuction : IGetCommissionPaidBySellerAuction
//    {
//        #region field
//        private readonly IAuctionRepository _auctionRepository;
//        #endregion

//        #region ctor
//        public GetCommissionPaidBySellerAuction(IAuctionRepository auctionRepository)
//        {
//            _auctionRepository = auctionRepository;
//        }
//        #endregion

//        #region Implemnetation
//        public async Task<decimal> Execute(int sellerId, CancellationToken cancellation)
//        {
//            return await _auctionRepository.CommisionPaidBySellerAuctions(sellerId, cancellation);
//        }
//        #endregion
//    }
//}

