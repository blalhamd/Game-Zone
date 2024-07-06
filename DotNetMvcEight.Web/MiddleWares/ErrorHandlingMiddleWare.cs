
namespace DotNetMvcEight.Web.MiddleWares
{
    public class ErrorHandlingMiddleWare 
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
               await _next(context);
            }
            catch (Exception ex)
            {
               await HandleErrorAsync(context, ex);
            }
        }

        private async Task HandleErrorAsync(HttpContext context, Exception ex)
        {
            if (!context.Response.HasStarted)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = new CustomizeError()
                {
                    Status = context.Response.StatusCode,
                    Message = ex.Message
                };

                switch (ex)
                {
                    case ItemNotFoundExecption:
                        response.Details = "Item Not Found Exception";
                        response.Error = (int)HttpStatusCode.NotFound;
                        break;
                    case ItemAlreadyExistExecption:
                        response.Details = "Item Already Exist Exception";
                        response.Error = (int)HttpStatusCode.Conflict;
                        break;
                    case BadRequestException:
                        response.Details = "Bad Request Exception";
                        response.Error = (int)HttpStatusCode.BadRequest;
                        break;
                    case InvalidOperationException:
                        response.Details = "Invalid Operation Exception";
                        response.Error = (int)HttpStatusCode.MethodNotAllowed;
                        break;
                    default:
                        response.Details = "Internal Server Error";
                        response.Error = context.Response.StatusCode;
                        break;
                }

                var json = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }
            else
            {
                await context.Response.WriteAsync(string.Empty);
            }

        }
    }

}
