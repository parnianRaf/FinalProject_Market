using System;
using AppCore.DtoModels;
using Repositories.Repository.ProductRepository;

namespace Service
{
    public class PavilionService : IPavilionService
    {
        #region field
        private readonly IPavilionRepository _pavilionRepository;
        #endregion

        #region ctor
        public PavilionService(IPavilionRepository pavilionRepository)
        {
            _pavilionRepository = pavilionRepository;
        }
        #endregion

        #region Implementation
        public async Task<List<PavilionDtoModel>> GetSellerPavilions(int sellerId, CancellationToken cancellation)
        {
            return await _pavilionRepository.GetSellerPavilions(sellerId, cancellation);
        }

        public async Task<PavilionDtoModel> GetPavilion(int id, CancellationToken cancellation)
        {
            return await _pavilionRepository.GetPavilion(id, cancellation);
        }
        #endregion

    }
}

