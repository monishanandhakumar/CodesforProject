using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeAPI.Models;

namespace EmployeeAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        SampleEntities1 db = new SampleEntities1();
        [Route("getemployee")]
        public HttpResponseMessage GET()
        {
         
            var Employees = db.employees.ToList();
            if (Employees.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Employees);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "No Data Found");
            }

        }
         // [HttpGet]
         // [Route("empbydept")]
          public HttpResponseMessage Get(string deptname)
          {
            var temp = "hi";
            /* var tempUser = db.employees.Where(u => (u.mobile == logininfo.mobile &&
             u.password == logininfo.password)).Select(x => new { x.name }).FirstOrDefault();*/
              var did = (from d in db.Departments
                             where d.dname == deptname
                             select d.deptid).SingleOrDefault();

                  var emp = (from e in db.employees
                             where e.deptid==did
                             select new
                             {
                                 name=e.name,age=e.age,gender=e.gender,mobile=e.mobile,e.emp_id
                             }
                             
                            ).ToList();

            return this.Request.CreateResponse(HttpStatusCode.OK,emp);
        }

        public HttpResponseMessage GET([FromUri]int? id)
        {
            float tax = 0;


                var emp=   db.employees.Find(id);

            if (emp != null)
            {
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


            else
            {
                string message = "Employee with "+ id.ToString() + " Doesnot  exists";
              //  return Request.CreateResponse(HttpStatusCode.OK,message);
               return Request.CreateResponse(HttpStatusCode.BadRequest, message);
            }
            


        }

    }
}
