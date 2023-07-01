using System;
using AppCore.DtoModels;
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
        private readonly ICookieService _setCookieService;
        #endregion

        #region ctor
        public PavilionAppService(IPavilionRepository pavilionRepository
            , IPavilionService pavilionService,
            IAccountServices accountServices,
            ICookieService setCookies)
        {

            _accountServices = accountServices;
            _pavilionService = pavilionService;
            _pavilionRepository = pavilionRepository;
            _setCookieService = setCookies;
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
            PavilionDtoModel pavilionDto= await _pavilionService.GetPavilion(id, cancellation);
            _setCookieService.SetCookies(pavilionDto.Id, "PavilionId");
            return pavilionDto;
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

