using System;
using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Seller.Command
{
    public interface IAddProduct
	{
		Task Execute(AddProductDto productDto,CancellationToken cancellation);
	}





}

