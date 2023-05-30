using System;
namespace AppCore.AppServices.Admin_.Command
{
	public interface IDeactiveComment
	{
		Task<bool> Execute(int id, CancellationToken cancellation);
	}
}

