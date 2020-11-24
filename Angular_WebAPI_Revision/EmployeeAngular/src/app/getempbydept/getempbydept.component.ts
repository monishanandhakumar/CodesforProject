import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/models/employee.model';
import { EmployeeService } from 'src/Services/employeeService';

@Component({
  selector: 'app-getempbydept',
  templateUrl: './getempbydept.component.html',
  styleUrls: ['./getempbydept.component.css']
})
export class GetempbydeptComponent implements OnInit {

  constructor(private empservice:EmployeeService) { }

  ngOnInit() {
  }
 deptname:string;
 employeedetails:any=[];
 getempofdept(deptname)
 {
    this.empservice.getempbydept(deptname).subscribe((data)=>{this.employeedetails=data; console.table(this.employeedetails)
      });

     
 }
}
