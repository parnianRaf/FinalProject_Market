using System;
namespace AppCore.AppServices.Admin_.Query
{
	public interface IGetCommissionPaidBySeller
	{
		Task<decimal> Execute(int sellerId, CancellationToken cancellation);
	}
}

