﻿using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Admin.Command
{
    public interface IEditPavilion
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }



}

