using Common.DTOs;
using MassTransit;
using Services.SMS;

namespace Messaging.Consumers
{
    public class SmsConsumer(ISmsService smsService) : IConsumer<SendSmsMessage>
    {
        private readonly ISmsService _smsService = smsService;

        public async Task Consume(ConsumeContext<SendSmsMessage> context)
        {
            var smsMessage = context.Message;

            await _smsService.SendSmsAsync(smsMessage.PhoneNumber, smsMessage.Message);
        }
    }
}
