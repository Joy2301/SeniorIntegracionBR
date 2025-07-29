using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExchangeRateAPI1.Business.Commands;
using ExchangeRateAPI1.Infrastructure.Providers;

namespace ExchangeRateAPI1.Controllers
{
    [Route("api1/v1/[controller]")]
    [ApiController]
    public class ExchangeRateController : ControllerBase
    {
        private readonly ExchangeRateCommandHandler _handler;
        public ExchangeRateController(ExchangeRateCommandHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> GetExchangeRate([FromBody] ExchangeRateCommand command)
        {
            try
            {
                var result = await _handler.HandleAsync(command);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", detail = ex.Message });
            }
        }
    }
}
