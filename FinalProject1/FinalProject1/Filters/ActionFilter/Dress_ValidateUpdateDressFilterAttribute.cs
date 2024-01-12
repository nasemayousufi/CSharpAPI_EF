using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using FinalProject1.Models;

namespace FinalProject1.Filters.ActionFilter
{
    public class Dress_ValidateUpdateDressFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var id = context.ActionArguments["id"] as int?;
            var dress = context.ActionArguments["dress"] as Dress;

            if (id.HasValue && dress != null && id != dress.Id)
            {
                context.ModelState.AddModelError("DressId", "DressId is not the same as my id.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
        }
    }

}

