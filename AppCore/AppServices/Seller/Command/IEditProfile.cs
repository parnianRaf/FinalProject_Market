using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Seller.Command
{
    public interface IEditProfile
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }





}

