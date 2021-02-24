using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PractikaASP
{
    public class ErrorMiddleware
    {
        private RequestDelegate nextDelegate;
        public ErrorMiddleware(RequestDelegate next) => nextDelegate = next;
        public async Task Invoke(HttpContext context)
        {
            await nextDelegate.Invoke(context);
            if (context.Response.StatusCode == 403)
                await context.Response.WriteAsync("Edge not supported", Encoding.UTF8);
            else if (context.Response.StatusCode == 404)
                await context.Response.WriteAsync("No content middleware response", Encoding.UTF8);
        }
    }
}