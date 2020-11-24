import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from 'src/Services/loginService';

@Component({
  selector: 'app-adminlayout',
  templateUrl: './adminlayout.component.html',
  styleUrls: ['./adminlayout.component.css']
})
export class AdminlayoutComponent implements OnInit {

  constructor(private loginservice:LoginService,private userrouter:Router) { }

  admincheck;
  ngOnInit() {
    debugger;
    //To avoid calling the method through url
    if(this.loginservice.loginsessionvariable)
    {
      this.admincheck=true;
    }
    else
    {
      this.admincheck=false;
      this.userrouter.navigate(['/home']);
    }
  }

  logOff()
  {
    debugger;
    this.loginservice.dologoff();
    //this.userrouter.navigate(['/home']);
  }


}
