using System;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using ZwajApp.API.Data;

namespace ZwajApp.API.Extensions
{
   public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this Microsoft.AspNetCore.Builder.IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if(contextFeature != null)
                    { 
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error."
                        }.ToString());
                    }
                });
            });
        }
        public static int ClacAge(this DateTime birthdate)
        {
            DateTime now = DateTime.Now;
            if (birthdate == DateTime.MinValue)
    {
        throw new ArgumentException("Date of birth is invalid.", nameof(birthdate));
    }

    if (birthdate >= now) return 0;

    var age = now.Year - birthdate.Year;
    if (birthdate.DayOfYear > now.DayOfYear)
    {
        age--;
    }
    return age;
        }
    
}
}