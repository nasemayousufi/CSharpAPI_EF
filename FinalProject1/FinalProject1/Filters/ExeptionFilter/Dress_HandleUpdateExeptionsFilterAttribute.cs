using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using FinalProject1.Models.Repository;

namespace FinalProject1.Filters.ExeptionFilter
{
    public class Dress_HandleUpdateExeptionsFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            var strDressId = context.RouteData.Values["id"] as string;
            if (int.TryParse(strDressId, out int dressId))
            {
                if (!DressRepository.DressExists(dressId))
                {
                    context.ModelState.AddModelError("Dress", "Dress does not exist anymore.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);
                }
            }
        }
    }
}

