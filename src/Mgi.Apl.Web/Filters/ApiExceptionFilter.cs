using Mgi.Framework.Core.ApiContract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace Mgi.Apl.Web.Filters
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var ex = context.Exception.InnerException ?? context.Exception;
            Log.Error(ex.GetType().ToString() + "：" + ex.Message + "——堆栈信息：" +
                ex.StackTrace);
            var response = new ApiResponse<object>(AppCode.InternalServerError);
            context.Result = new OkObjectResult(response);
        }
    }
}
