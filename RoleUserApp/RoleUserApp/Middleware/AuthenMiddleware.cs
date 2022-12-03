using System.Text;

namespace Ntq.Training.App.Middleware
{
    public class AuthenMiddleware
    {
        private readonly RequestDelegate _nextMiddleware;
        public AuthenMiddleware(RequestDelegate next)
        {
            _nextMiddleware = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            if (httpContext.Request.Path.ToString().ToLower() == "/contentmiddleware")
            {
                await httpContext.Response.WriteAsync("Hello from the content creating middleware", Encoding.UTF8);
            }
            else
            {
                await _nextMiddleware.Invoke(httpContext);
            }
        }
    }
}
