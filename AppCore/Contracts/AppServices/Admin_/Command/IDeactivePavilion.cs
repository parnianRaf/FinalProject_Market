using System;
namespace AppCore.AppServices.Admin_.Command
{
	public interface IDeactivePavilion
	{
		Task<bool> Execute(int id, CancellationToken cancellation);
	}
}

