﻿using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Customer.Command
{
    public interface IPayDirectOrder
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }




}
