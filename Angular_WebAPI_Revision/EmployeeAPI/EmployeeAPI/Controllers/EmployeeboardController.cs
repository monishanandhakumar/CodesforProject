using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeAPI.Models;
namespace EmployeeAPI.Controllers
{
    public class EmployeeboardController : ApiController
    {
        SampleEntities1 db = new SampleEntities1();

        public HttpResponseMessage GET([FromUri]int? id)
        {
            float tax = 0;

                dynamic salary = db.employees.Find(id).salary;


                if (salary > 0)
                {
                    if ((salary * 12) > 300000)
                    {
                        tax = (salary * 12) / 10;

                    }
                    else
                    {
                        tax = 0;

                    }
                }

           


            return Request.CreateResponse(HttpStatusCode.OK, tax);


        }
    }
}
