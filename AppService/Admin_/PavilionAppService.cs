using System;
using AppCore.DtoModels;
using Repositories.Repository.ProductRepository;

namespace AppService.Admin_
{
    public class PavilionAppService : IPavilionAppService
    {
        #region field
        private readonly IPavilionRepository _pavilionRepository;
        #endregion

        #region ctor
        public PavilionAppService(IPavilionRepository pavilionRepository)
        {
            _pavilionRepository = pavilionRepository;
        }
        #endregion

        #region Implementation
        public async Task<List<PavilionDtoModel>> GetSellerPavilions(int sellerId, CancellationToken cancellation)
        {
            return await _pavilionRepository.GetSellerPavilions(sellerId, cancellation);
        }

        public async Task<bool> RemovePavilion(int id, CancellationToken cancellation)
        {
            return await _pavilionRepository.RemovePavilion(id, cancellation);

        }

        public async Task<bool> EditPavilion(PavilionDtoModel pavilionDto, CancellationToken cancellation)
        {
            return await _pavilionRepository.EditPavilion(pavilionDto, cancellation);

        }

        public async Task<PavilionDtoModel> GetPavilion(int id,CancellationToken cancellation)
        {
            return await _pavilionRepository.GetPavilion(id, cancellation);
        }

        public async Task<bool> ActiveProduct(int id,CancellationToken cancellation)
        {
            return await _pavilionRepository.AcceptPavilion(id, cancellation);
        }
        #endregion
    }
}

