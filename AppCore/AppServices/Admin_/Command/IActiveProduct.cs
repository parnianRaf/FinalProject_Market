using System;
using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Admin_.Command
{
	public interface IActiveProduct
	{
		Task Execute(int id, CancellationToken cancellation);
	}
}

