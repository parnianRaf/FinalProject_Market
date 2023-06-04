using System;
namespace AppCore.AppServices.Admin_.Query
{
	public interface IGetCommissionPaidBySellerAuction
    {
		Task<decimal> Execute(int sellerId, CancellationToken cancellation);
	}
}

