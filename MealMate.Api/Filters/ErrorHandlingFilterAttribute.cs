namespace MealMate.Api;

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        ProblemDetails problemDetails = new ProblemDetails
        {
            Title = context.Exception.Message.ToString(),
            Status = (int?)HttpStatusCode.InternalServerError,
        };

         context.Result = new ObjectResult(problemDetails);
         context.ExceptionHandled = true;
    }
}
