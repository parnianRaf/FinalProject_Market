using System;
using AppCore.DtoModels;
using AppService.Admin_.Command;
using Repositories.Repository.ProductRepository;
using Service;

namespace AppService.Admin_
{
    public class PavilionAppService : IPavilionAppService
    {
        #region field
        private readonly IAccountServices _accountServices;
        private readonly IPavilionService _pavilionService;
        private readonly IPavilionRepository _pavilionRepository;
        #endregion

        #region ctor
        public PavilionAppService(IPavilionRepository pavilionRepository
            , IPavilionService pavilionService,
            IAccountServices accountServices)
        {

            _accountServices = accountServices;
            _pavilionService = pavilionService;
            _pavilionRepository = pavilionRepository;
        }
        #endregion

        #region Implementation
        public async Task<List<PavilionDtoModel>> GetSellerPavilions(CancellationToken cancellation)
        {
            int sellerId = _accountServices.GetCurrentUser();
            return await _pavilionService.GetSellerPavilions(sellerId, cancellation);
        }

        public async Task<PavilionDtoModel> GetPavilion(int id,CancellationToken cancellation)
        {
            return await _pavilionService.GetPavilion(id, cancellation);
        }






        public async Task<bool> RemovePavilion(int id, CancellationToken cancellation)
        {
            return await _pavilionRepository.RemovePavilion(id, cancellation);

        }

        public async Task<bool> EditPavilion(PavilionDtoModel pavilionDto, CancellationToken cancellation)
        {
            return await _pavilionRepository.EditPavilion(pavilionDto, cancellation);

        }


        public async Task<bool> ActiveProduct(int id,CancellationToken cancellation)
        {
            return await _pavilionRepository.AcceptPavilion(id, cancellation);
        }
        #endregion
    }
}

