using System;
using AppCore.DtoModels.DirectOrder;

namespace AppCore.AppServices.Admin_.Query
{
	public interface IGetAllPaidOrders
	{
		Task<List<DetailedDirctOrderDto>> Execute(CancellationToken cancellation);
	}
}

