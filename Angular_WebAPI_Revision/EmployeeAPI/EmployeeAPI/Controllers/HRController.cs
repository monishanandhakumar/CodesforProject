using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeAPI.Models;

namespace EmployeeAPI.Controllers
{
    public class HRController : ApiController
    {
        SampleEntities1 db = new SampleEntities1();
        //HTTP: GET,GET WITH VARIOUS PARAMETES,POST,PUT ,DELETE
        //LOGIC

        //display dept detauls of particular location

        //return type of IHttpActionResult
        // public IHttpActionResult Get(string location)

            [HttpGet]
           [Route("getdeptloc")]
        public IHttpActionResult Getdeptbylocation(string location)
        {

            var dept = (from d in db.Departments
                        where d.location == location
                        select d).ToList();

            if(dept.Count>0)
                
            { 
                return Ok(dept); }
            else
            {
                return BadRequest("No data found!!!");
            }
            
        }

        [HttpPost]
        public IHttpActionResult AddDept(Department department)
        {
          if (department!=null)

            {

                //check for deptid already exists
                db.Departments.Add(department);
                db.SaveChanges();
                return Ok("Added Successfully");
            }
            else
            {
                return BadRequest("Data Not Added!!! ");
            }

        }


    }
}
