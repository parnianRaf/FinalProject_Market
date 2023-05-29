using System;
using AppCore.AppServices.Admin.Command;
using AppCore.DtoModels.Admin;
using Microsoft.AspNetCore.Identity;
using Repositories.UserRepository;

namespace AppService.Admin
{
	public class LogIn:ILogIn
	{
        #region field
        private readonly IAdminRepository _repository;
        #endregion

        #region ctor
        public LogIn(IAdminRepository repository)
        {
            _repository = repository;
        }
        #endregion
        public async Task<SignInResult> Execute(LogInAdminDto adminDto,CancellationToken cancellation)
		{
            return await _repository.LogIn(adminDto, cancellation);
		}
	}
}

