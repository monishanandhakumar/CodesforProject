using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using EmployeeAPI.Models;

namespace EmployeeAPI.Controllers
{
    public class LoginController : ApiController
    {
        SampleEntities1 db = new SampleEntities1();
        public dynamic Post(employee logininfo)
        {
            try
            {
                /* var encodedpass = db.employees.Where(u => (u.mobile == logininfo.mobile))
                     .Select(x => new { x.password }).FirstOrDefault();*/

                var user = (from emp in db.employees
                            where emp.mobile == logininfo.mobile
                            select emp.password).FirstOrDefault();
                var e = user;


                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecode_byte = Convert.FromBase64String(e);
                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                string pass = new String(decoded_char);


                var tempUser = (from emp in db.employees
                                where emp.mobile == logininfo.mobile && pass == logininfo.password
                                select emp.name).FirstOrDefault();

                /* var tempUser = db.employees.Where(u => (u.mobile == logininfo.mobile &&
                 pass == logininfo.password)).Select(x=>new {x.name }).FirstOrDefault();*/

                /* var tempUser = db.employees.FirstOrDefault(u => u.mobile== logininfo.mobile && 
                 u.password==logininfo.password);*/


                /*   var userdata = db.LoginDetails
                          .Where(y => (y.Email == login.Email && y.Password == login.Password))
                          .Select(x => new { x.UserID, x.UserName });*/
                if (tempUser != null)
                {
                    return this.Request.CreateResponse(HttpStatusCode.OK, tempUser);
                    //  return new Response {/* Status = "Success",*/ Message = logininfo.mail };

                }
                else
                {
                    return this.Request.CreateResponse(HttpStatusCode.OK, "Invalid");
                    //return new Response { /*Status = "loginfailed",*/Message = "Invalid" };
                }
            }

            catch(Exception e)
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, "Invalid");
            }
        }

    }
}
