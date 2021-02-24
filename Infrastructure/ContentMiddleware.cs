using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractikaASP.Infrastructure
{
    public class ContentMiddleware
    {
        private RequestDelegate nextDeletegate;
        private UptimeService service;
        public ContentMiddleware(RequestDelegate next, UptimeService up) { nextDeletegate = next;  service = up; }
        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.ToString().ToLower() == "/middleware")
                await context.Response.WriteAsync($"Это данные с промежудачного слоя {service.Update()}ms", System.Text.Encoding.UTF8);
            else
                await nextDeletegate.Invoke(context);
        }
    }
}
