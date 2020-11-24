import { HttpClient } from '@angular/common/http';

import{Injectable} from '@angular/core'
import { NgForm } from '@angular/forms';

@Injectable({providedIn:"root"})
export class EmployeeService
{

    constructor(private http:HttpClient,private http1:HttpClient)
        {

        }

    getEmployee()
      {
         
         // debugger;
         return this.http.get("http://localhost:61316/getemployee");
        
      }  

    getTax(id:number)
    {
       // let empid=id.value;
        debugger;
      console.log(id);
        return this.http.get("http://localhost:61316/api/Employee/"+id);
    }

    //get emp details for particular department

    getempbydept(deptname:string)
    {
         debugger;
        console.log("Inservice",deptname);
        //return this.http.get("http://localhost:61316/api/Employee?deptname=UX");

        //below will not work
    //  return this.http.get("http://localhost:61316/api/Employee/"+deptname);
      
    //query string
     return this.http.get("http://localhost:61316/api/Employee?deptname="+deptname);
    }
}