using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PractikaASP.Infrastructure
{
    public class BrowserTypeMiddleware
    {
        private RequestDelegate nextDelegate;
        public BrowserTypeMiddleware(RequestDelegate request) => nextDelegate = request;
        public async Task Invoke(HttpContext context)
        {
            context.Items["EdgeBrowser"] = context.Request.Headers["User-Agent"]
                .Any(v=>v.ToLower().Contains("edge"));
            await nextDelegate.Invoke(context);
        }
    }
}
