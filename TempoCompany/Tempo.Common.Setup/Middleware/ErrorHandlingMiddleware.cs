using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using Serilog;
using Serilog.Context;
using Microsoft.AspNetCore.Diagnostics;
using Tempo.Common.Setup.Util.Extension;

namespace Tempo.Knight.Setup.Middleware
{
    /// <summary>
    /// Handle for take erro into application and custom mensagem for external consum
    /// </summary>
    public class ErrorHandlingMiddleware : IExceptionHandler
    {
        const string _msgContactSuport = "Please notify the Tempo Gamer support team TI for assistance!  Erro: ";
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            using var property = LogContext.PushProperty("UserName", httpContext.User?.Identity?.Name ?? "anônimo");
            Log.Error(exception, "Error");

            var result = JsonSerializer.Serialize(new { error = ExtractTitleFromMessage(exception.Message.Truncate(32))});

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await httpContext.Response.WriteAsync(result, cancellationToken: cancellationToken);

            return true;
        }

        private string ExtractTitleFromMessage(string message)
        {

            if (string.IsNullOrEmpty(message))
                return "Unknown error";

            var lines = message.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            return  lines.Length > 0 ? _msgContactSuport +  lines[0].Split(':').FirstOrDefault() ?? lines[0] : "Unknown error";
        }
    }
}
