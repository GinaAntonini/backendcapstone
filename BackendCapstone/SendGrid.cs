using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace Example
{
    public class SendgridEmail
    {
        public static string ApiKey =  ConfigurationManager.AppSettings["sendgridkey"];

        private static void Main()
        {
            ExecuteTestEmail().Wait();
        }

        public static async Task ExecuteTestEmail()
        {
            //var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
            var client = new SendGridClient(ApiKey);
            var from = new EmailAddress("info@mpmnashville.com", "Emergency Report Generator");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("gina@mpmnashville.com", "Gina");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

        public static async Task Execute(string toEmail, string name, string bodyOfEmail)
        {
            //var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
            var client = new SendGridClient(ApiKey);
            var from = new EmailAddress("info@mpmnashville.com", "Emergency Report Generator");
            var subject = "Emergency report from On Call Manager";
            var to = new EmailAddress(toEmail, name);
            var plainTextContent = bodyOfEmail;
            var htmlContent = bodyOfEmail;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}