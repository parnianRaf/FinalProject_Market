using System;
namespace AppCore.AppServices.Admin.Query
{
	public interface IGetCategories
	{
		Task<List<Category>> Execute(CancellationToken cancellation);
	}
}

