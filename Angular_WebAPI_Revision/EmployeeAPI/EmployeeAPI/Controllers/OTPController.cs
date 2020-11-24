using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Http;

namespace EmployeeAPI.Controllers
{
    public class OTPController : ApiController
    {

        public async Task<int> GetOtp(/*string email*/)
        {
            //Add below code in webconfig
            /*
             * 
             *  <system.net>
    <mailSettings>
      <smtp deliveryMethod="Network">
        <network host="smtp.gmail.com" port="587" userName="dotnettraining2011@gmail.com" password="training09" enableSsl="true"/>
      </smtp>
    </mailSettings>
  </system.net>*/
            string email = "monishanandhakumar04@gmail.com";

         //   if (db.Users.FirstOrDefault(u => u.UserEmail == email) is null) return 0;
            Random generator = new Random();
            int r = generator.Next(100000, 1000000);
            SmtpClient smtp = new SmtpClient();
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("dotnettraining2011@gmail.com");
            mailMessage.To.Add(email);
            mailMessage.Subject = "Forgot Password";
            mailMessage.Body = "Your OTP is " + r;
            await Task.Run(() => smtp.SendAsync(mailMessage, null));
            return r;
        }

        [HttpGet]
        public async Task ResendOtp(string email, int otp)
        {
            SmtpClient smtp = new SmtpClient();
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("dotnettraining2011@gmail.com");
            mailMessage.To.Add(email);
            mailMessage.Subject = "Forgot Password";
            mailMessage.Body = "Dear User,Your OTP is " + otp;
            await Task.Run(() => smtp.SendAsync(mailMessage, null));
        }
    }
}
