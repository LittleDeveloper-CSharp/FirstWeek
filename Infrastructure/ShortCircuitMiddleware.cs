using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PractikaASP.Infrastructure
{
    public class ShortCircuitMiddleware
    {
        private RequestDelegate nextDelegate;
        public ShortCircuitMiddleware(RequestDelegate next) => nextDelegate = next;
        public async Task Invoke(HttpContext context)
        {
            if ((bool)(context.Items["EdgeBrowser"] as bool?))
                context.Response.StatusCode = 403;
            else
                await nextDelegate.Invoke(context);
                
        }
    }
}