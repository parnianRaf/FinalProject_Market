﻿using AppCore.DtoModels;
using AppCore.DtoModels.Customer;
using AppCore.DtoModels.Product;
using AppCore.DtoModels.Seller;
using Microsoft.AspNetCore.Identity;

namespace AppCore.AppServices.Admin_.Command
{
    public interface IEditPavilion
    {
        Task<bool> Execute(PavilionDtoModel pavilionDto, CancellationToken cancellation);
    }



}

