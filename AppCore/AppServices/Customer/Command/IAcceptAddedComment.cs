using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Customer.Command
{
    public interface IAcceptAddedComment
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }

}

