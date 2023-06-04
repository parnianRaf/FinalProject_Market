using System;
namespace AppCore.DtoModels.User
{
	public class LogInUser
	{
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsRememberMe { get; set; }
    }
}

