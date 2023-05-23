using AppCore.DtoModels;
using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Admin.Command
{
    public interface IEditPavilion
    {
        Task Execute(PavilionDtoModel productDto, CancellationToken cancellation);
    }



}

