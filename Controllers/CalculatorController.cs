using CalcAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CalcAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous] // test question just wanted exposed endpoint
public class CalculatorController : ControllerBase
{
    private readonly ICalculatorService _calculatorService;
    CalculatorController(ICalculatorService calculatorService)
    {
        _calculatorService = calculatorService;
    }
    
    [HttpPost("CalculateTimeAngle")]
    
    public IActionResult CalculateTimeAngle([FromBody] DateTime? timeRequest)
    {
        if(!timeRequest.HasValue)
        {
            return BadRequest("Invalid or missing time value");
        }
        var angle = _calculatorService.CalculateTimeAngle(timeRequest.Value);
        return Ok(angle);
    }
    public IActionResult CalculateTimeAngle([FromBody] int? hour, int? minute)
    {
        if(!hour.HasValue || !minute.HasValue)
        {
            return BadRequest("Invalid or missing hour or minute value");
        }
        var angle = _calculatorService.CalculateTimeAngle(hour.Value, minute.Value);
        return Ok(angle);
    }
}
