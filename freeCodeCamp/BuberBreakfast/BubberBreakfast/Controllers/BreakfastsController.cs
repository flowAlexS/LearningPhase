using BubberBreakfast.Models;
using BubberBreakfast.ServiceErrors;
using BubberBreakfast.Services.Breakfasts;
using BuberBreakfast.Contracts.Breakfast;
using Microsoft.AspNetCore.Mvc;

namespace BubberBreakfast.Controllers
{
    public class BreakfastsController : ApiController
    {
        private readonly IBreakfastService _breakfastService;

        public BreakfastsController(IBreakfastService breakfastService)
        {
            _breakfastService = breakfastService;
        }

        [HttpPost]
        public IActionResult CreateBreakfast(CreateBreakfastRequest request)
        {
            var breakfast = new Breakfast(
                Guid.NewGuid(),
                request.Name,
                request.Description,
                request.StartDateTime,
                request.EndDateTime,
                DateTime.UtcNow,
                request.Savory,
                request.Sweet);

            var createBreakfastResult = _breakfastService.CreateBreakfast(breakfast);

            return createBreakfastResult.Match(
                onError: errors => Problem(errors),
                onValue: created => CreatedAsGetBreakfast(breakfast));
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetBreakfast(Guid id)
        {
            var getBreakfastResult = _breakfastService.GetBreakfast(id);

            return getBreakfastResult.Match(
                onValue: breakfast => Ok(MapBreakfastResponse(breakfast)),
                onError: errors => Problem(errors));
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
        {
            var breakfast = new Breakfast(
                id,
                request.Name,
                request.Description,
                request.StartDateTime,
                request.EndDateTime,
                DateTime.UtcNow,
                request.Savory,
                request.Sweet);

            var updatedBreakfastResult = _breakfastService.UpsertBreakfast(breakfast);

            return updatedBreakfastResult.Match(
                onValue: updated => updated.isNewlyCreated ? CreatedAsGetBreakfast(breakfast) :  NoContent(),
                onError: errors => Problem(errors));
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteBreakfast(Guid id)
        {
            var deleteBreakfastResponse = _breakfastService.DeleteBreakfast(id);

            return deleteBreakfastResponse.Match(
                onValue: deleted => NoContent(),
                onError: errors => Problem(errors));
        }

        private static BreakfastResponse MapBreakfastResponse(Breakfast breakfast)
        => new  (breakfast.Id,
                breakfast.Name,
                breakfast.Description,
                breakfast.StartDateTime,
                breakfast.EndDateTime,
                breakfast.LastModifiedDateTime,
                breakfast.Savory,
                breakfast.Sweet);

        private CreatedAtActionResult CreatedAsGetBreakfast(Breakfast breakfast)
        => CreatedAtAction(
                    actionName: nameof(GetBreakfast),
                    routeValues: new { id = breakfast.Id },
                    value: MapBreakfastResponse(breakfast));
    }
}
