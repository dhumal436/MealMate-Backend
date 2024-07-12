using Microsoft.AspNetCore.Mvc;

namespace MealMate.Api.Controller.ErrorController;

public class ErrorController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }

}
