using API.Controllers;
using API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("Error/{code}")]
[ApiExplorerSettings(IgnoreApi =true)]
public class ErrorsController:BaseAPIController
{
    public IActionResult Error(int code)
    {
        return new ObjectResult(new APIResponse(code));
    }

}
