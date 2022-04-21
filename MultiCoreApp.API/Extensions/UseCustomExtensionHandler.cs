using Microsoft.AspNetCore.Diagnostics;
using MultiCoreApp.API.DTOs;
using Newtonsoft.Json;

namespace MultiCoreApp.API.Extensions
{
    public static class UseCustomExtensionHandler
    {

        //Extensionlar static olmak zorundadır işleri araya girip bir görevi yerine getirmek 
        public static void UseCustomExeption(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500;//Server hatası
                    context.Response.ContentType = "application/json";
                    var error=context.Features.Get<IExceptionHandlerFeature>();
                    if (error!=null)
                    {
                        var ex = error.Error;
                        if (ex!=null)
                        {
                            ErrorDto errorDto = new ErrorDto();
                            errorDto.Status = 500;
                            errorDto.Errors.Add(ex.Message);
                            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorDto));
                        }
                    }
                });
            });
        }
    }
}
