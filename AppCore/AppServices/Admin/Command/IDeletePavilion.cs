using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Admin.Command
{
    public interface IDeletePavilion
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }



}

