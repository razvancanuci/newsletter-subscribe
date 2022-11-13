using backend.API.Models;
using backend.Application.Models;
using backend.Application.Services;
using Microsoft.AspNetCore.Mvc;


namespace backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriberController : ControllerBase
    {
        private readonly ISubscriberService _subscriberService;
        public SubscriberController(ISubscriberService subscriberService)
        {
            _subscriberService = subscriberService;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewSubscriber(NewSubscriberModel model)
        {
            if (await _subscriberService.GetSubscriberByEmail(model.Email) != null)
            {
                return BadRequest(ApiResponse<string>.Fail(new[] { new ValidationError(null, "Email is already subscribed") }));
            }
            var subscriberResponse = await _subscriberService.AddSubscriber(model);

            return Created("/api/Subscriber", ApiResponse<string>.Success(subscriberResponse.Email));

        }

        [HttpDelete("{subscriberId}")]
        public async Task<IActionResult> DeleteSubscriberById(Guid subscriberId)
        {
            if (await _subscriberService.GetSubscriberById(subscriberId) == null)
            {
                return NotFound(ApiResponse<string>.Fail(new[] { new ValidationError(null, "Id not found") }));
            }
            await _subscriberService.DeleteSubscriberById(subscriberId);


            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetSubscribers()
        {
            return Ok(ApiResponse<IEnumerable<SubscriberResponseModel>>.Success(await _subscriberService.GetSubscribers()));
        }

        [HttpGet("statistics")]
        public async Task<IActionResult> GetSubscribersStats()
        {
            return Ok(ApiResponse<SubscriberStatsModel>.Success(await _subscriberService.GetSubscriberStats()));
        }

        [HttpGet("{subscriberId}")]
        public async Task<IActionResult> GetEmailById(Guid subscriberId)
        {
            var subscriber = await _subscriberService.GetSubscriberById(subscriberId);

            if (subscriber == null)
            {
                return NotFound(ApiResponse<string>.Fail(new[] { new ValidationError(null, "Id not found") }));
            }
            return Ok(ApiResponse<string>.Success(subscriber.Email));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSubscriberByEmail(string subscriberEmail)
        {
            var subscriber = await _subscriberService.GetSubscriberByEmail(subscriberEmail);
            if (subscriber == null)
            {
                return NotFound(ApiResponse<string>.Fail(new[] { new ValidationError(null, "Email not found") }));
            }
            await _subscriberService.DeleteSusbcriberByEmail(subscriberEmail);

            return NoContent();

        }
    }
}
