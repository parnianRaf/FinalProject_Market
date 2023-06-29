using AppCore.DtoModels.Product;
using AppCore.DtoModels.Seller;

namespace AppCore.AppServices.Seller.Command
{
    public interface IEditProfile
    {
        Task Execute(EditSellerDto entity, CancellationToken cancellation);
    }





}

