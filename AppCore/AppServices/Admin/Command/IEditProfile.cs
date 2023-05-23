using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Admin.Command
{
    public interface IEditProfile
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }





}

