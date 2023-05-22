using System;
namespace AppCore.AppServices.Seller.Query
{
	public interface IGetCategories
	{
		Task<List<Category>> Execute(CancellationToken cancellation);
	}
}

