using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using System.Net;
using Bll;
using Microsoft.AspNetCore.Cors;
using Bll.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
        readonly IUserService _service;
        public SendEmailController(IUserService service)
        {
            this._service = service;
        }

        [EnableCors]
        [HttpGet("EmailAddReport/{eMail}/{language}")]
        public IActionResult EmailAddReport(string eMail, string language)
        {
            if(language == "he")
            { 
                string text = "<div style=\"text-align:right\">\r\n<p> ,משתמש יקר </p>\r\n<p>\r\nהדיווח שלך התקבל בהצלחה למערכת, כמו כן תוכל לצפות בו על מפת האתר<br/>\r\nיש לך אפשרות להסתכל בכל הדיוחים שלך ב'דיווחים שלי' וכן לעדכן או למחוק אותם<br/>\r\n</p>\r\n<p>אנחנו מודים לך על תרומתך לאתר שלנו </p>\r\n<p>המשך חוויה מהנה</p>\r\n<p>צוות האתר</p>\r\n<p> .נא לא לענות למייל זה </p>\r\n</div>";
                SendMail.BasicEmail(eMail, "הדיוח התקבל בהצלחה", text);
            }
            else 
            {
                string text = "<div>\r\n<p>Dear user, </p>\r\n<p>\r\nYour report has been successfully received into the system, also you can view it on the site map.<br/>\r\nYou have the option to look at all your reports in 'My reports' and update or delete them.<br/>\r\n</p>\r\n<p>We Thank you for your contribution to our site. </p>\r\n<p>Continue to have a pleasant experience!</p>\r\n<p>Site team</p>\r\n<p>Please do not reply to this email. </p>\r\n</div>";
                SendMail.BasicEmail(eMail, "The report was received successfully", text);
            }
            return Ok("Email send successfully");
        }

        [EnableCors]
        [HttpGet("EmailRegister/{eMail}/{code}/{language}")]
        public IActionResult EmailRegister(string eMail, int code, string language)
        {
            if(language == "he")
            { 
                string text = "<div style=\"text-align:right\">\r\n<p> ,משתמש יקר</p>\r\n<p>\r\nברוך הבא לאתר שלנו<br/>\r\nהאתר המאחד את הקהילה בצורה נוחה ביותר<br/>\r\n</p>\r\n<p> .אנחנו מודים לך על אמונך לאתר שלנו </p>\r\n<p>"+code+ " :אנא הכנס את את הקוד הבא כדי לאשר את חשבונך</p>\r\n\r\n<p>צוות האתר</p>\r\n<p> .נא לא לענות למייל זה </p>\r\n</div>";
                SendMail.BasicEmail(eMail, "תודה שנרשמת! אישור חשבון", text);
            }
            else 
            {
                string text = "<div>\r\n<p> Dear user,</p>\r\n<p>\r\nWelcome to our site<br/> \r\nThe site that unites the community in the most convenient way<br/>\r\n</p>\r\n<p>We thank you for your trust in our site. </p>\r\n<p>Please enter the following code to confirm your account: " + code + " </p>\r\n\r\n<p>Site team</p>\r\n<p> Please don't reply to this email. </p >\r\n</div>";
                SendMail.BasicEmail(eMail, "Thank you for signing up! Account verification", text);
            }
            return Ok("Email send successfully");
        }

        [EnableCors]
        [HttpGet("EmailForgetPassword/{eMail}/{language}")]
        public IActionResult EmailForgetPassword(string eMail, string language)
        {
            if (!_service.EmailExist(eMail))
                return Ok("This email don't exist");

            Random rnd = new Random();
            int code = rnd.Next(10000, 100000);
            
            if(language == "he")
            { 
                string text = "<div style=\"text-align:right\">\r\n<p> ,משתמש יקר</p>\r\n\r\n<p>"+code+" :להלן הסיסמא החדשה שלך</p>\r\n<p>.אנא התחבר שוב עם המייל הזה ועם הסיסמא הזאת\"ל</p>\r\n<p> 'לאחר מכן תוכל להחליף את סיסמאתך. לצורך זה תכנס ל'פרטים אישיים</p>\r\n\r\n<p>צוות האתר</p>\r\n<p> .נא לא לענות למייל זה </p>\r\n</div>";
                SendMail.BasicEmail(eMail, "סיסמא חדשה", text);
            }
            else 
            {
                string text = "<div>\r\n<p>Dear user, </p>\r\n\r\n<p>Below your new password: " + code + "</p>\r\n<p>Please log in again with this email and this password.</p>\r\n<p> Then you can change your password. For this purpose, go to 'personal details'</p>\r\n\r\n<p>Webite team</p>\r\n<p>Please don't reply to this email </p>\r\n</div>";
                SendMail.BasicEmail(eMail, "New password", text);
            }
            _service.UpdatePassword(eMail, code.ToString());
            return Ok("Email send successfully");
        }
    }
}