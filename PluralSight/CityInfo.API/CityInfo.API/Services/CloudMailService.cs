namespace CityInfo.API.Services
{
    public class CloudMailService : IMailService
    {
        private readonly string _mailTo;
        private readonly string _mailFrom;

        public CloudMailService(IConfiguration configuration)
        {
            _mailTo = configuration["mailSettings:mailToAddress"];
            _mailFrom = configuration["mailSettings:mailFromAddress"];
        }

        public void Send(string subject, string message)
        {
            // Send mail..

            Console.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with name {nameof(CloudMailService)}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");
        }
    }
}
