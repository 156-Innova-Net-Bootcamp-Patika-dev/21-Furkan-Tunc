using API.Middlewares;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Extensions
{
    public static class ExceptionMiddlewareExtension //Middleware'i startup da tanımlayabilmek için yazılan extension metot
    {
        public static IApplicationBuilder UseExceptionMiddlaware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
