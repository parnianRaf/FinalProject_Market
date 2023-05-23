using AppCore.DtoModels.Admin;
using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Admin.Command
{
    public interface IEditProfile
    {
        Task Execute(EditAdminDto productDto, CancellationToken cancellation);
    }





}

