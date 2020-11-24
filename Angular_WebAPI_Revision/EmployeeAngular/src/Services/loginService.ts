import { HttpClient } from '@angular/common/http';

import{Injectable} from '@angular/core'
import { NgForm } from '@angular/forms';
import { Employee } from 'src/models/employee.model';
import { Router } from '@angular/router';
@Injectable({providedIn:"root"})
export class LoginService
{
    constructor(private http:HttpClient,private userrouter:Router )
    {

    }
    readonly uri = "http://localhost:61316/api/Login";
     
  //to check user in logged in  or not
  loginsessionvariable;
  loginuser
  loginCheck()
  {
      this.loginuser= sessionStorage.getItem('username');
      if(this.loginuser!="")
      {
          this.loginsessionvariable=true;
      }
      else{
          this.loginsessionvariable=false;
      }
    
  }

    // checking employee  login  creditals from webapi
    empLogin(emp:any)
    {
    return  this.http.post(this.uri,emp);
    }
    //log off 
public loginuservariable:boolean;
   public dologoff()
    {
        debugger;
        sessionStorage.clear();
        this.loginuservariable=false;
       this.userrouter.navigate(['/home']);
    }
}