using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExchangeRateAPI1.Business.Commands;
using ExchangeRateAPI1.Infrastructure.Providers;
using ExchangeRateAPI3.Infrastructure.ApiResponse;

namespace ExchangeRateAPI1.Controllers
{
    [Route("api3/v1/[controller]")]
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
                var total = await _handler.HandleAsync(command);

                var response = new ExchangeResponse<decimal>
                {
                    StatusCode = 200,
                    Message = "Success",
                    Data = total
                };

                return Ok(response);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new ExchangeResponse<decimal>
                {
                    StatusCode = 404,
                    Message = ex.Message,
                    Data = default
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ExchangeResponse<decimal>
                {
                    StatusCode = 500,
                    Message = "Internal Server Error",
                    Data = default
                });
            }
        }
    }
}
