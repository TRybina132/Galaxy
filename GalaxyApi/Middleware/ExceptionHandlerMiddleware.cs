using System.Text;

namespace GalaxyApi.Middleware
{
    public class ExceptionHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(Exception ex)
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(ex.Message);
                MemoryStream stream = new MemoryStream(byteArray);
                context.Response.Body = stream;
                context.Response.StatusCode = 501;
            }
        }
    }
}
