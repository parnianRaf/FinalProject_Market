using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Admin.Query
{
    public interface IGetDirectOrder
    {
        Task Execute(int customerId, CancellationToken cancellation);
    }




}

