using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace playCore
{
    public class MyMiddleware
    {
        private RequestDelegate _next;
        private string _greetings;
        private IServiceProvider _services;

        public MyMiddleware(RequestDelegate next, string greetings, IServiceProvider services) {
            _next = next;
            _greetings = greetings;
            _services = services;
        }

        public async Task Invoke(HttpContext context) {
            await context.Response.WriteAsync(_greetings + ", middleware");
            await context.Response.WriteAsync("request from" + context.Request.Method);
        }
    }

}
