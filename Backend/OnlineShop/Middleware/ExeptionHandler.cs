using System.Text;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using OnlineShop.Middleware.Models;

namespace OnlineShop.Middleware;

public static class ExceptionHandlerMiddlewareExtension
{
    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(handler =>
        {
            handler.Run(async context =>
            {
                try
                {
                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    if (exceptionHandlerPathFeature is {Error: ExceptionHandler exceptionContext})
                    {
                        context.Response.StatusCode =
                            exceptionContext.ErrorCode ?? StatusCodes.Status500InternalServerError;
                        context.Response.ContentType = "application/json";

                        var jsonString = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(
                            new ApiResponse<object>
                            {
                                errorMessage = string.IsNullOrEmpty(exceptionContext.Message)
                                    ? "متاسفانه مشکلی پیش امده است."
                                    : exceptionContext.Message,
                                errorCode = exceptionContext.ErrorCode
                            }));

                        await context.Response.Body.WriteAsync(jsonString);
                    }
                    else
                    {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "application/json";
                        if (exceptionHandlerPathFeature != null)
                            await context.Response.WriteAsync(JsonConvert.SerializeObject(
                                new ApiResponse<object>
                                {
                                    errorMessage = "متاسفانه مشکلی پیش امده است.",
                                     data = exceptionHandlerPathFeature.Error,
                                    errorCode = 500
                                }));
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
            });
        });
        return app;
    }
}