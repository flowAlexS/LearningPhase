using BuberBreakfast.Contracts.Breakfast;
using Microsoft.AspNetCore.Mvc;

namespace BubberBreakfast.Controllers
{
    [ApiController]
    [Route("breakfasts")]
    public class BreakfastsController : ControllerBase
    {
        [HttpPost("")]
        public IActionResult CreateBreakfast(CreateBreakfastRequest request)
        {
            return Ok();
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetBreakfast(Guid id)
        {
            return Ok(id);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
        {
            return Ok(request);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteBreakfast(Guid id)
        {
            return Ok();
        }
    }
}
