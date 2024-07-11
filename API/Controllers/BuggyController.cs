using API.Controllers;
using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API;
public class BuggyController:BaseAPIController
{
    private readonly DataContext _dataContext;

    public BuggyController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet("notfound")]
    public ActionResult GetNotFoundRequest()
    {
        var things= _dataContext.Products.Find(42);
        if(things==null)
        {
            return NotFound(new APIResponse(404));
        }
        return Ok();
    }
    
    [HttpGet("servererror")]
    public ActionResult GetServerError()
    {
        var things= _dataContext.Products.Find(42);
        var resRetiurn=things.ToString();

        return Ok();
    }
    [HttpGet("badrequest")]
    public ActionResult badrequest()
    {
        return BadRequest();
    }

    [HttpGet("badrequest/{id}")]
    public ActionResult GetNotFoundRequest(int id)
    {
        return Ok();
    }

}
