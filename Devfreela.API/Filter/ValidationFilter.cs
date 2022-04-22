using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Devfreela.API.Filter
{
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(GetMessages(context));
            }
        }

        private static List<string> GetMessages(ActionExecutingContext context)
        {
            return context.ModelState.SelectMany(m => m.Value.Errors)
                                .Select(e => e.ErrorMessage).ToList();
        }
    }
}
