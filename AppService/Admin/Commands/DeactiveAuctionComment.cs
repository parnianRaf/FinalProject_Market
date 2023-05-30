using System;
using AppCore.AppServices.Admin_.Command;
using Repositories.Repository.ProductRepository;
using Repositories.UserRepository;

namespace AppService.Admin.Commands
{
    public class DeactiveAuctionComment : IDeactiveAuctionComment
    {
        #region field
        private readonly IAuctionRepository _auctionRepository;
        #endregion

        #region ctor
        public DeactiveAuctionComment(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }
        #endregion

        #region Implementation
        public async Task<bool> Execute(int id, CancellationToken cancellation)
        {
            return await _auctionRepository.RejectComment(id, cancellation);
        }
        #endregion
    }
}

