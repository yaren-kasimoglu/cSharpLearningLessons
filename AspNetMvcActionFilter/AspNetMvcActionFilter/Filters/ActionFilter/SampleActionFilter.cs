using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetMvcActionFilter.Filters.ActionFilter
{
    public class SampleActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //Before the ection executed
            base.OnActionExecuted(context);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //After action executing
            base.OnActionExecuting(context);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            //After action executing
            base.OnResultExecuted(context);
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            //After action executing
            base.OnResultExecuting(context);
        }
    }
}

