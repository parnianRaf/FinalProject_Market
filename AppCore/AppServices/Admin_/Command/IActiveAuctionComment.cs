using System;
namespace AppCore.AppServices.Admin_.Command
{
	public interface IActivAuctionComment
	{
		Task<bool> Execute(int id, CancellationToken cancellation);
	}
}

