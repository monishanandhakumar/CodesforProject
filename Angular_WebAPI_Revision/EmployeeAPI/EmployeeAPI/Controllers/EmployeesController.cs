using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Security;
using System.Net.Security;
using EmployeeAPI.Models;
using System.Text;

namespace EmployeeAPI.Controllers
{
    public class EmployeesController : ApiController
    {
        private SampleEntities1 db = new SampleEntities1();

        // GET: api/Employees
        public IQueryable<employee> Getemployees()
        {
            return db.employees;
        }

        // GET: api/Employees/5
        [ResponseType(typeof(employee))]
        public IHttpActionResult Getemployee(int id)
        {
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/Employees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putemployee(int id, employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.emp_id)
            {
                return BadRequest();
            }

            db.Entry(employee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!employeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Employees
        [ResponseType(typeof(employee))]
        public IHttpActionResult Postemployee(employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            #region Encryptionmethod1
                 try
                 {
                     //Password Encryption Code
                       byte[] encData_byte = new byte[employee.password.Length];
                       encData_byte = System.Text.Encoding.UTF8.GetBytes(employee.password);
                       string encodedpassword = Convert.ToBase64String(encData_byte);
                       employee.password = encodedpassword;


                 }
                 catch (Exception ex)
                 {
                     throw new Exception("Error in base64Encode" + ex.Message);
                 }
            #endregion

            #region Encryption Method2
         /*   var shaSHA1 = System.Security.Cryptography.SHA1.Create();
            var inputEncodingBytes = Encoding.ASCII.GetBytes(employee.password);
            var hashString = shaSHA1.ComputeHash(inputEncodingBytes);*/
            #endregion
            db.employees.Add(employee);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (employeeExists(employee.emp_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = employee.emp_id }, employee);
        }

        // DELETE: api/Employees/5
        [ResponseType(typeof(employee))]
        public IHttpActionResult Deleteemployee(int id)
        {
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            db.employees.Remove(employee);
            db.SaveChanges();

            return Ok(employee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool employeeExists(int id)
        {
            return db.employees.Count(e => e.emp_id == id) > 0;
        }
    }
}