namespace CityInfo.API.Services
{
    public class CloudMailService : IMailService
    {
        private string _mailTo = "admin@mycompany.com";
        private string _mailFrom = "noreply@mycompany.com";

        public void Send(string subject, string message)
        {
            // Send mail..

            Console.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with name {nameof(CloudMailService)}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");
        }
    }
}
