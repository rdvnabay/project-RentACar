namespace Core.Utilities.Mail
{
    public interface IEmailService
    {
        void Send(EmailMessage emailMessage);
    }
}
