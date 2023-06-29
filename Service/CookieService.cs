using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Service
{
    public class CookieService : ICookieService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public CookieService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public void SetCookies(int id,string key)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddHours(30);
            httpContextAccessor.HttpContext.Response.Cookies.Append(key, id.ToString(), options);
        }

        public string ReadCookies(string key)
        {
            return httpContextAccessor.HttpContext.Request.Cookies[key];
        }
    }
}

