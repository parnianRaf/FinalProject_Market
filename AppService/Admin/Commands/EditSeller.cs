using System;
using AppCore.AppServices.Admin.Command;
using AppCore.DtoModels.Customer;
using AppCore.DtoModels.Seller;
using Microsoft.AspNetCore.Identity;
using Repositories.UserRepository;

namespace AppService.Admin.Commands
{
    public class EditSeller : IEditSeller
    {
        #region field
        private readonly ISellerRepository _sellerRepository;
        #endregion

        #region ctor
        public EditSeller(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }
        #endregion

        #region Implementation
        public async Task<bool> Execute(EditSellerDto sellerDto, CancellationToken cancellation)
        {
            return await _sellerRepository.UpdateSeller(sellerDto, cancellation);

        }
        #endregion
    }
}

