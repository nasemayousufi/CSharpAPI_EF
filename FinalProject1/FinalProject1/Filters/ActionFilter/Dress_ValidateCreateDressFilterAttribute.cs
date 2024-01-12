using FinalProject1.Models;
using FinalProject1.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FinalProject1.Filters.ActionFilter
{
    public class Dress_ValidateCreateDressFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var dress = context.ActionArguments["dress"] as Dress;
            if (dress == null)
            {
                context.ModelState.AddModelError("Dress", "Dress object is null");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else
            {
                var existingDress = DressRepository.GetDressByProperties(dress.Brand, dress.Gender, dress.Color, dress.Size);
                if (existingDress != null)
                {
                    context.ModelState.AddModelError("Dress", "Dress object is null.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
            }
        }
    }
}

