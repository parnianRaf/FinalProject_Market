using System;
namespace AppCore.AppServices.Admin_.Command
{
	public interface IActiveComment
	{
		Task<bool> Execute(int id, CancellationToken cancellation);
	}
}

