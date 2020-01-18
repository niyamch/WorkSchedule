using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;


namespace Service.Authentication
{
    public class TokenManagerMiddleware : IMiddleware
    {
        private readonly IAuthenticationService _authService;

        public TokenManagerMiddleware(IAuthenticationService authService)
        {
            _authService = authService;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (await _authService.IsCurrentActiveToken())
            {
                await next(context);
                return;
            }
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
    }
}
