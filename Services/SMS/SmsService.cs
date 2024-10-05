
namespace Services.SMS
{
    public class SmsService : ISmsService
    {
        public async Task SendSmsAsync(string phoneNumber, string message)
        {
            // Implement logic for sending sms

            await Task.Delay(1000);
        }
    }
}
