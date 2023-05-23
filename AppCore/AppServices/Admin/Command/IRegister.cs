using AppCore.DtoModels.Admin;
using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Admin.Command
{
    public interface IRegister
    {
        Task Execute(AddAdminDto entity, CancellationToken cancellation);
    }





}

