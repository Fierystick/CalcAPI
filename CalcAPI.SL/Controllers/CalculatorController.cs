using System.Runtime.ExceptionServices;
using CalcAPI.SL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CalcAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous] // test question just wanted exposed endpoint
public class CalculatorController : ControllerBase
{
    private readonly ICalculatorService _calculatorService;
    public CalculatorController(ICalculatorService calculatorService)
    {
        _calculatorService = calculatorService;
    }
    
    [HttpPost("CalculateTimeAngle")]
    public IActionResult CalculateTimeAngle([FromBody] TimeAngleRequest request)
    {
        if (request.Time.HasValue)
        {
            var angle = _calculatorService.CalculateTimeAngle(request.Time.Value);
            return Ok(angle);
        }
        
        if (request.Hour.HasValue && request.Minute.HasValue)
        {
            var angle = _calculatorService.CalculateTimeAngle(request.Hour.Value, request.Minute.Value);
            return Ok(angle);
        }
        
        return BadRequest("Provide either Time or both Hour and Minute");
    }
}

