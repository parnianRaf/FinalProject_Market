using System;
using AppCore.DtoModels.Auction;

namespace AppCore.AppServices.Admin_.Query
{
	public interface IGetAllAuctions
	{
		Task<List<DetailedAuctionDto>> Execute(CancellationToken cancellation);
	}
}

