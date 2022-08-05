using FinancialControlApi.Features.Income.Queries;
using Microsoft.AspNetCore.Mvc;

namespace FinancialControlApi.Features.Income;

[ApiController]
[Route("[controller]")]
public class IncomeController : ControllerBase
{
    private readonly IGetAllIncomes getAllIncomes;

    public IncomeController(IGetAllIncomes getAllIncomes)
    {
        this.getAllIncomes = getAllIncomes;
    }

    [HttpGet]
    [Route("GetAllIncomes")]
    public IActionResult GetAllIncomes()
    {
        try
        {
            var incomes = getAllIncomes.Handler();

            if (incomes.Count == 0)
                return NotFound();

            return Ok();
        }
        catch (Exception e)
        {
            //TODO: log
            return BadRequest();
        }
    }
}