﻿using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Admin.Command
{
    public interface ILogIn
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }





}
