using Microsoft.AspNetCore.Mvc;
using PortfolioService.Application.DTOs;
using PortfolioService.Application.Interfaces;

namespace PortfolioService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PortfolioController : ControllerBase
{
    private readonly IPortfolioService _portfolioService;

    public PortfolioController(IPortfolioService portfolioService)
    {
        _portfolioService = portfolioService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreatePortfolioRequest request,
        CancellationToken cancellationToken)
    {
        var id = await _portfolioService.CreatePortfolioAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var portfolios = await _portfolioService.GetAllAsync(cancellationToken);
        return Ok(portfolios);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var portfolio = await _portfolioService.GetByIdAsync(id, cancellationToken);

        if (portfolio is null)
            return NotFound();

        return Ok(portfolio);
    }
    [HttpPut("{id:guid}")]
public async Task<IActionResult> Update(
    Guid id,
    [FromBody] UpdatePortfolioRequest request,
    CancellationToken cancellationToken)
{
    var updated = await _portfolioService.UpdatePortfolioAsync(id, request, cancellationToken);

    if (!updated)
        return NotFound();

    return NoContent();
}

[HttpDelete("{id:guid}")]
public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
{
    var deleted = await _portfolioService.DeletePortfolioAsync(id, cancellationToken);

    if (!deleted)
        return NotFound();

    return NoContent();
}

/*testing global exception middleware
[HttpGet("test-error")]
public IActionResult TestError()
{
    throw new Exception("Testing global exception middleware");
}
*/

}