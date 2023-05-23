﻿using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Seller.Command
{
    public interface IGetProfile
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }





}

