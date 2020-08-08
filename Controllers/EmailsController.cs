using Hotel.API.Data;
using Hotel.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly IEmailSender _emailSender;

        public EmailsController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpGet]
        public ActionResult<string> SendEmail()
        {
            var message = new Message(new string[] { "Khumomogorsi@gmail.com" }, "Test Email", "This is the content of our email.");
            _emailSender.SendEmail(message);

            return Ok("Email Sent");
        }
    }
}