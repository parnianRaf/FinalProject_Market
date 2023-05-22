using System;
using AppCore.AppServices.Seller.Command;

namespace AppService.Seller.Command
{
	public class EditProduct:IEditProduct
	{

        public Task Execute(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}

