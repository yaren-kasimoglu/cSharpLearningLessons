using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetMvcActionFilter.Filters.ActionFilter
{
    public class ExceptionFilterAttribute :Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new ContentResult()
            {
                Content = context.Exception.ToString()
            };
        }
    }
}
