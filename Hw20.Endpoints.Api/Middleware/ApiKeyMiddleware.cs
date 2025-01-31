using App.Domain.Core.Hw20.Config;
using App.Domain.Core.Hw20.Result;

namespace Hw20.Endpoints.Api.Middleware
{

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseApiKeyValidation(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiKeyMiddleware>();
        }
    }


    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly SiteSettings _siteSettings;
        private static readonly List<string> WhitelistedActions = new()
        {
            "/admin",
        };

        public ApiKeyMiddleware(RequestDelegate next, SiteSettings siteSettings)
        {
            _next = next;
            _siteSettings = siteSettings;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.ToString();

            if (WhitelistedActions.Any(x => path.ToUpper().Contains(x.ToUpper())))
            {
                if (context.Request.Headers.TryGetValue("ApiKey", out var apiKey) && !string.IsNullOrEmpty(apiKey))
                {
                    if (apiKey == _siteSettings.ApiKey)
                    {
                        await _next(context);
                        return;
                    }
                    else
                    {
                       
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        await context.Response.WriteAsJsonAsync("AccessDenied: Invalid API key.");
                        return;
                    }
                }
                else
                {
                    
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsJsonAsync("AccessDenied: Invalid API key.");
                    return;

                }
            }
            context.Response.StatusCode = StatusCodes.Status200OK;
            await _next(context);
           
        }
    }

}

