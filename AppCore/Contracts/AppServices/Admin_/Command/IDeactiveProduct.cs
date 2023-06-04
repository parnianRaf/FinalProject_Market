using System;
namespace AppCore.AppServices.Admin_.Command
{
	public interface IDeactiveProduct
	{
		Task<bool> Execute(int id, CancellationToken cancellation);
	}
}

