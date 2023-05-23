using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Customer.Query
{
    public interface IGetFactors
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }




}

