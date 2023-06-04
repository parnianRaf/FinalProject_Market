using System;
namespace AppCore.AppServices.Admin_.Command
{
	public interface IDeactiveAuctionComment
	{
		Task<bool> Execute(int id, CancellationToken cancellation);
	}
}

