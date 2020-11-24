import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  emp:any={};
  constructor(private http:HttpClient) { }

  ngOnInit() {


  }

addEmployee(emp)
{
  return this.http.post("",emp);
}

}
