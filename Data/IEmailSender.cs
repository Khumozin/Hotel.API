using Hotel.API.Models;

namespace Hotel.API.Data
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}