using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using FinalProject1.Models.Repository;

namespace FinalProject1.Filters.ActionFilter
{
    public class Dress_ValidateDressIdFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)

        {
            base.OnActionExecuting(context);

            var dressId = context.ActionArguments["id"] as int?;

            if (dressId.HasValue)

            {

                if (dressId.Value <= 0)

                {

                    context.ModelState.AddModelError("DressID", "DressID is invalid.");

                    context.Result = new BadRequestObjectResult(context.ModelState);

                }

                else if (!DressRepository.DressExists(dressId.Value))

                {

                    context.ModelState.AddModelError("DressID", "DressID does not exist!.");

                    context.Result = new NotFoundObjectResult(context.ModelState);

                }

            }

        }
    }
}
