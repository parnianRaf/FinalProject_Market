using System;
using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Seller.Command
{
	public interface IEditProduct
	{
		Task Execute(EditProductDto entity,CancellationToken cancellation);
	}
}

