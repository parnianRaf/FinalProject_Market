using System;
using AppCore.DtoModels;

namespace AppCore.AppServices.Admin_.Query
{
	public interface IGetSellerPavilions
	{
		Task<List<PavilionDtoModel>> Execute(int sellerId,CancellationToken cancellation);
	}
}

