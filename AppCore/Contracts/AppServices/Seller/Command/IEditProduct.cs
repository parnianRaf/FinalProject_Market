using System;
using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Seller.Command
{
	public interface IEditProduct
	{
		Task<bool> Execute(EditProductDto entity,CancellationToken cancellation);
	}
}

