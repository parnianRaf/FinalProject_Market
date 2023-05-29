using AppCore.DtoModels.Customer;
using AppCore.DtoModels.Product;
using AppCore.DtoModels.Seller;

namespace AppCore.AppServices.Admin.Query
{
    public interface IGetSeller
    {
        Task<FullDetailSellerDto> Execute(int id,CancellationToken cancellation);
    }

}

