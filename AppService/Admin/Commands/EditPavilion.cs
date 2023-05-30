using System;
using AppCore.AppServices.Admin.Command;
using AppCore.DtoModels;
using AppCore.DtoModels.Customer;
using Microsoft.AspNetCore.Identity;
using Repositories.Repository.ProductRepository;
using Repositories.UserRepository;

namespace AppService.Admin.Commands
{
    public class EditPavilion : IEditPavilion
    {
        #region field
        private readonly IPavilionRepository _pavilionRepository;
        #endregion

        #region ctor
        public EditPavilion(IPavilionRepository pavilionRepository)
        {
            _pavilionRepository = pavilionRepository;
        }
        #endregion

        #region Implementation

        public async Task<bool> Execute(PavilionDtoModel pavilionDto, CancellationToken cancellation)
        {
            return await _pavilionRepository.EditPavilion(pavilionDto, cancellation);

        }
        #endregion
    }
}

