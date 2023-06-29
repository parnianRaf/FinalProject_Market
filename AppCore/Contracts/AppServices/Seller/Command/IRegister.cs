using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Seller.Command
{
    public interface IRegister
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }





}

