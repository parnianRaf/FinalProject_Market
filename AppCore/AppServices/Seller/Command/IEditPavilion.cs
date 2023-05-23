using AppCore.DtoModels;
using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Seller.Command
{
    public interface IEditPavilion
    {
        Task Execute(PavilionDtoModel entity, CancellationToken cancellation);
    }





}

