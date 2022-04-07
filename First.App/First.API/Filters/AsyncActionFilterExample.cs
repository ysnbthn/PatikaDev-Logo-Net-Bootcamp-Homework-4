using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace First.API.Filters
{
    public class AsyncActionFilterExample : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // action çalışmadan önce herhangi bir işlem yapılabilir.
            var result = await next();
            // action çalıştıktan sonra herhangi bir işlem yapılabilir.
        }
    }
}
