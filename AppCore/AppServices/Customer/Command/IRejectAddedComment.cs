using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Customer.Command
{
    public interface IRejectAddedComment
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }

}

