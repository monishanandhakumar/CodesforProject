import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/Services/loginService';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private loginservice:LoginService) { }
  
  usersessionvariable;
  username;
  ngOnInit() {
    this.username=this.loginservice.loginuser;
    this.usersessionvariable=this.loginservice.loginuservariable;
console.log("home oninit");
  }

  logOff()
  {
    debugger;
    this.loginservice.dologoff();
    
    this.usersessionvariable=this.loginservice.loginuservariable;
    //this.userrouter.navigate(['/home']);
  }
  
}
