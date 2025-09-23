using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldContainer.Controllers;

[Route("[controller]")]
[ApiController]
public class HelloWorldController : ControllerBase
{

    private readonly ILogger<HelloWorldController> _logger;
    
    public HelloWorldController(ILogger<HelloWorldController> logger)
    {
        _logger = logger;
    }

    [HttpGet("HelloWorld")]
    public IActionResult Get()
    {
        _logger.LogInformation("HelloWorld endpoint was called.");
        return Ok("Hello, World!");
    }


    [HttpGet("HelloWorldError")]
    public IActionResult Error()
    {
        _logger.LogError("HelloWorld Error endpoint was called.");
        return Ok("Hello, World!");
    }
}
