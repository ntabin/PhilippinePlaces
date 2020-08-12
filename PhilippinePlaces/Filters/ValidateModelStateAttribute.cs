namespace PhilippinePlaces.Filters
{
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using PhilippinePlaces.Messages;

    public class ValidateModelStateAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var response = new WebResponse
                {
                    Errors = context.ModelState.Keys
                    .SelectMany(key => context.ModelState[key].Errors.Select(x => new { key, x.ErrorMessage }))
                    .Select(a => a.ErrorMessage)
                    .ToList()
                };

                context.Result = new BadRequestObjectResult(response);
            }
        }
    }
}
