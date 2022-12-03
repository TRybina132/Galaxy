namespace GalaxyApi.Middleware;

public class CorsResponseMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await next(context);
        
        context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
    }
}