using System;
namespace AppCore.AppServices.Seller.Command
{
	public interface IEditProduct
	{
		Task Execute(int id,CancellationToken cancellation);
	}
}

