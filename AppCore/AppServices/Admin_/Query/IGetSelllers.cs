using AppCore.DtoModels.Customer;
using AppCore.DtoModels.Product;
using AppCore.DtoModels.Seller;

namespace AppCore.AppServices.Admin.Query
{
    public interface IGetSellers
    {
        Task<List<DetailSellerDto>> Execute(CancellationToken cancellation);
    }

}

