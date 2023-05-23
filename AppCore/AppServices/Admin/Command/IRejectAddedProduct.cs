using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Admin.Command
{
    public interface IRejectAddedProduct
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }

}

