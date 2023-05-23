using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Admin.Query
{
    public interface IGetFactors
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }




}

