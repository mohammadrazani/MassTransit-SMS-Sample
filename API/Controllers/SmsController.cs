using Common.DTOs;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SmsController(IPublishEndpoint publishEndpoint) : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

        [HttpPost("send")]
        public async Task<IActionResult> SendSms([FromBody] SendSmsMessage request)
        {
            await _publishEndpoint.Publish(request);

            return Ok("SMS Sent");
        }
    }
}
