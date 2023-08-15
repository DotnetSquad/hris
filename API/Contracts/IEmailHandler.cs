namespace API.Contracts;

public interface IEmailHandler
{
    void sendEmail(string toEmail, string subject, string htmlMessage);
}
