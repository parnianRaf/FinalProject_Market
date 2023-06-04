using AppCore.DtoModels.Admin;
using AppCore.DtoModels.Product;
using Microsoft.AspNetCore.Identity;

namespace AppCore.AppServices.Admin_.Command
{
    public interface ILogIn
    {
        Task<SignInResult> Execute(LogInAdminDto adminDto, CancellationToken cancellation);
    }





}

