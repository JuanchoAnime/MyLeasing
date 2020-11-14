namespace MyLeasing.Api.Infrastructure.Repository
{
    using Microsoft.Extensions.Configuration;
    using MimeKit;
    using MailKit.Net.Smtp;
    using MyLeasing.Api.Infrastructure.Repository.Interface;

    public class Mail : IMail
    {
        private readonly IConfiguration _configuration;

        public Mail(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public void SendMail(string toEmail, string toName, string subject, string body, string bodyType = "plain")
        {
            var from = _configuration["Mail:From"];
            var name = _configuration["Mail:FromName"];
            var smtp = _configuration["Mail:Smtp"];
            var port = _configuration["Mail:Port"];
            var password = _configuration["Mail:Password"];

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(name, from));
            message.To.Add(new MailboxAddress(toName, toEmail));
            message.Subject = subject;
            message.Body = new TextPart(bodyType) { Text = body };
            using (var client = new SmtpClient())
            {
                client.Connect(smtp, int.Parse(port), false);
                client.Authenticate(from, password);
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
