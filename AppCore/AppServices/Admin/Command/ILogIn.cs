using AppCore.DtoModels.Admin;
using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Admin.Command
{
    public interface ILogIn
    {
        Task Execute(LogInAdminDto entity, CancellationToken cancellation);
    }





}

