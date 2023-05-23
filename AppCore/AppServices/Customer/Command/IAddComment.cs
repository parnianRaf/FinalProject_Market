using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Customer.Command
{
    public interface IAddComment
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }




}

