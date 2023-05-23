using System;
namespace AppCore.AppServices.Customer.Query
{
	public interface IGetCategories
	{
		Task<List<Category>> Execute(CancellationToken cancellation);
	}
}

