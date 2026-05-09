
using CreditScoreService.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CreditScoreService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CreditScoreController : ControllerBase
{
    [HttpPost("calculate")]
    public IActionResult CalculateCreditScore(
        CalculateCreditScoreRequest request)
    {
        return Ok(request);
    }
}