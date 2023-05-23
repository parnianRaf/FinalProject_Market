using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Admin.Command
{
    public interface IAddPavilionList
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }



}

