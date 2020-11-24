import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Employee } from 'src/models/employee.model';
import { LoginService } from 'src/Services/loginService';

@Component({
  selector: 'app-emplogin',
  templateUrl: './emplogin.component.html',
  styleUrls: ['./emplogin.component.css']
})
export class EmploginComponent implements OnInit {

  constructor(private loginservice:LoginService,private userrouter:Router) { }
emp:any={};
  loginstatus;
  loggedinempdetails;
  ngOnInit() {
  }
err;
  doLogin()
  {
    //debugger;
    //console.log(this.emp);
    //Admin
    if(this.emp.mobile==123 &&this.emp.password=="123")
    {
      debugger;
      this.loginservice.loginuservariable=true;
      sessionStorage.setItem('username','admin')
      //to check any user is logged in or not 
      this.loginservice.loginCheck();
      this.userrouter.navigate(['/adminlayout']);

    }

    else if(this.emp!= null)
    {
       this.loginservice.empLogin(this.emp).subscribe((data)=>{
        this.loggedinempdetails=data as string;
        debugger;
        console.log(this.loggedinempdetails);
         sessionStorage.setItem('username',this.loggedinempdetails);
          //to check any user is logged in or not 
      this.loginservice.loginCheck();
         if(data!='Invalid')
         {
          this.loginservice.loginuservariable=true;
          this.userrouter.navigate(['/userlayout']);
          
         }
         
       else
       {
         this.userrouter.navigate(['/login']);
         this.err="Invalid Mobile No or Password!!!";
       }
       });
      }
      else{
        this.err="Please enter valid creditianls!!!";
      }
  }
}
