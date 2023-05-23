using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Customer.Command
{
    public interface IEditProfile
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }





}

