using DynamicsEmailSender.model;
using Microsoft.AspNetCore.Mvc;

namespace DynamicsEmailSender.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DynamicsEmailSenderController : Controller
    {
        [HttpPost]
        public IActionResult ProcessingMailData([FromBody] MailData mailData)
        {

            EmailSender emailSender = new EmailSender();
            var email = mailData.Email;
            var name = mailData.username;
            var url = mailData.Url;
            var prise = Convert.ToDouble(mailData.Price);
            var pris = (prise / 10).ToString();
            
            emailSender.MailSender(email, name, url, pris);
            

            return Ok();
        }
    }
}
