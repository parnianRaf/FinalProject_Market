using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Customer.Query
{
    public interface IGetProfile
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }





}

