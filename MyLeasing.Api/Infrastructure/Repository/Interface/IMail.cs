namespace MyLeasing.Api.Infrastructure.Repository.Interface
{
    public interface IMail
    {
        void SendMail(string toEmail, string toName, string subject, string body, string bodyType = "plain");
    }
}
