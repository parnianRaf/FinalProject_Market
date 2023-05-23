using AppCore.DtoModels;
using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Seller.Command
{
    public interface IAddPavilion
    {
        Task Execute(PavilionDtoModel entity, CancellationToken cancellation);
    }





}

