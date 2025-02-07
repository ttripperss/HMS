using HMS.DTO_s;

namespace HMS.Abstractions
{
    public interface IEmailService
    {
        void SendEmail(SendEmailDto emailModel);
    }
}
