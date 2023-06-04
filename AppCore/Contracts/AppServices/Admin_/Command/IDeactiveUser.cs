using System;
namespace AppCore.AppServices.Admin_.Command
{
	public interface IDeactiveUser
	{
		Task<bool> Execute(int id, CancellationToken cancellation);
	}
}

