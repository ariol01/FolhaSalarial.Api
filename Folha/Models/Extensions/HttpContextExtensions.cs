namespace Folha.Models.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GerarCaminho(this IHttpContextAccessor httpContextAccessor)
        {
            return httpContextAccessor.HttpContext.Request.Host.Value;
        }
    }
}
