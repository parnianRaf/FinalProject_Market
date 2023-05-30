using System;
using AppCore.AppServices.Admin_.Command;
using AppCore.DtoModels;
using Repositories.Repository.ProductRepository;

namespace AppService.Admin.Commands
{
    public class DeactivePavilion : IDeactivePavilion
    {
        #region field
        private readonly IPavilionRepository _pavilionRepository;
        #endregion

        #region ctor
        public DeactivePavilion(IPavilionRepository pavilionRepository)
        {
            _pavilionRepository = pavilionRepository;
        }
        #endregion

        #region Implementation

        public async Task<bool> Execute(int id, CancellationToken cancellation)
        {
            return await _pavilionRepository.RemovePavilion(id, cancellation);

        }
        #endregion
    }
}

