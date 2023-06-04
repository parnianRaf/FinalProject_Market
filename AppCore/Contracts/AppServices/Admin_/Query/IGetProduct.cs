using AppCore.DtoModels.Product;

namespace AppService.Admin.Queries
{
    public interface IGetProduct
    {
        Task<DetailedProductDto> Execute(int id, CancellationToken cancellation);
    }
}