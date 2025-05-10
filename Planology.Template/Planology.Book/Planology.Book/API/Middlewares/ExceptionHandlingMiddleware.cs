namespace API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(
            RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
                if (context.Response.StatusCode >= 400 && !context.Response.HasStarted)
                {
                    var error = new
                    {
                        Status = context.Response.StatusCode,
                        Error = GetFriendlyError(context.Response.StatusCode),
                        Instance = context.Request.Path
                    };

                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsJsonAsync(error);
                }
            }
            catch (Exception ex)
            {
                var error = new
                {
                    Status = 500,
                    Error = "خطای سرور - یه چیزی اشتباه رفت!",
                    Detail = context.Request.Path.Value.Contains("/debug") ? ex.Message : null
                };

                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(error);
            }
        }
        private string GetFriendlyError(int statusCode)
        {
            return statusCode switch
            {
                400 => "درخواست نامعتبر - داری چرت میفرستی!",
                401 => "نیاز به لاگین داری عزیزم",
                403 => "اینجا رو که نباید می اومدی!",
                404 => "چیزی که میخوای وجود نداره",
                418 => "من یک قوری چایی هستم!",
                _ => "خطای ناشناخته(خدا خودش درستش کنه): " + statusCode
            };
        }
    }
}