﻿using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Seller.Command
{
    public interface IGetAuction
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }





}

