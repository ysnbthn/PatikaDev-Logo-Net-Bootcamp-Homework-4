using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace First.App.Middlewares
{
    public class AppVersionControlMiddleware : IMiddleware
    {
        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            throw new System.NotImplementedException();
        }
    }
}
