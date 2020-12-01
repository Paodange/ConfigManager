using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Mgi.Apl.Web.Filters
{
    public class ApiInvokeLogFilter : ActionFilterAttribute
    {
        readonly ILogger log;
        public ApiInvokeLogFilter(ILogger<ApiInvokeLogFilter> logger)
        {
            log = logger;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Items["Stopwatch"] = Stopwatch.StartNew();
            log.LogInformation("Request begin, TraceId:{traceId},Url:{url},Method:{method}"
                , context.HttpContext.TraceIdentifier, context.HttpContext.Request.Path, context.HttpContext.Request.Method);
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            var sw = context.HttpContext.Items["Stopwatch"] as Stopwatch;
            sw.Stop();
            if (context.Exception == null)
            {
                log.LogInformation("Request end, TraceId:{traceId},Duration:{duration}ms ,Url:{url},Method:{method},Result:{@result}",
                    context.HttpContext.TraceIdentifier, sw.ElapsedMilliseconds, context.HttpContext.Request.Path, context.HttpContext.Request.Method, context.Result);
            }
            else
            {
                log.LogInformation("Request end, TraceId:{traceId},Duration:{duration}ms ,Url:{url},Method:{method} Exception:{Exception}",
                     context.HttpContext.TraceIdentifier, sw.ElapsedMilliseconds, context.HttpContext.Request.Path, context.HttpContext.Request.Method, context.Exception.ToString());
            }
        }
    }
}
