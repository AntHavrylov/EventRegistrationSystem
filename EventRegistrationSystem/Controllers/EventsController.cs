using EventRegistrationSystem.Mapping;
using EventRegistrationSystem.Models.Dtos;
using EventRegistrationSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EventRegistrationSystem.Controllers
{
    [ApiController]
    public class EventsController : ControllerBase
    {

        private readonly IEventService _eventService;
        private readonly IUserService _userService;

        public EventsController(IEventService eventService, 
            IUserService userService)
        {
            _eventService = eventService;
            _userService = userService;
        }

        [HttpGet(ApiEndpoints.Events.GetAll)]
        public async Task<IActionResult> GetEvents(
            CancellationToken ct) 
        {
            var events = await _eventService.GetAllEventsAsync(ct);
            return Ok(events);
        }

        [HttpGet(ApiEndpoints.Events.GetById)]
        public async Task<IActionResult> GetEventById(
            [FromRoute] string eventId,
            CancellationToken ct) 
        {
            var eventItem = await _eventService.GetEventByIdAsync(eventId, ct);
            return Ok(eventItem);
        }

        [Authorize]
        [HttpPost(ApiEndpoints.Events.Create)]
        public async Task<IActionResult> CreateEvent(
            [FromBody] CreateEventRequest request,
            CancellationToken ct)
        {

            var userId = User.FindFirst(ClaimTypes.NameIdentifier);
            var result = await _eventService.CreateEventAsync(
                request.ToEvent(userId!.Value),
                ct);
            if (!result) 
            {
                return BadRequest();
            }
            return Ok();
        }

        [Authorize]
        [HttpGet(ApiEndpoints.Events.GetRegistrations)]
        public async Task<IActionResult> GetEventRegistrations(
            [FromRoute] string eventId, 
            CancellationToken ct) 
        {
            
            return Ok();
        }
                
        [HttpPost(ApiEndpoints.Events.Register)]
        public async Task<IActionResult> RegisterForEvent(
            [FromRoute] string eventId,
            RegisterEventRequest request,
            CancellationToken ct)
        {

            return Ok();
        }
    }


}
