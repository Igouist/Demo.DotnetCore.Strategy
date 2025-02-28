using Microsoft.AspNetCore.Mvc;

namespace Demo.DotnetCore.Strategy.Controllers;

[ApiController]
[Route("[controller]")]
public class DemoController(
    ILogger<DemoController> logger) 
    : ControllerBase
{
    [HttpGet]
    public object Get()
    {
        return new
        {
            Status = "OK",
        };
    }
}