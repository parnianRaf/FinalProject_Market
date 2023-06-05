//using System;
//using AppCore.AppServices.Admin_.Command;
//using Repositories.Repository.ProductRepository;
//using Repositories.UserRepository;

//namespace AppService.Admin.Commands
//{
//    public class ActiveAuctionComment : IActivAuctionComment
//    {
//        #region field
//        private readonly IAuctionRepository _auctionRepository;
//        #endregion

//        #region ctor
//        public ActiveAuctionComment(IAuctionRepository auctionRepository)
//        {
//            _auctionRepository = auctionRepository;
//        }
//        #endregion

//        #region Implementation
//        public async Task<bool> Execute(int id, CancellationToken cancellation)
//        {
//            return await _auctionRepository.AcceptComment(id, cancellation);
//        }
//        #endregion
//    }
//}

