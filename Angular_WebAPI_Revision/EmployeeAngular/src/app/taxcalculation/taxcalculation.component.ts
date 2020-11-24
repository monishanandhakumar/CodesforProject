import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { EmployeeService } from 'src/Services/employeeService';

@Component({
  selector: 'app-taxcalculation',
  templateUrl: './taxcalculation.component.html',
  styleUrls: ['./taxcalculation.component.css']
})
export class TaxcalculationComponent implements OnInit {

  
  constructor(private empservice:EmployeeService) { }

  ngOnInit() {
  }

  Taxamount;
 /* calculateTax(forminfo:NgForm)
  {
    console.log(forminfo.value)
    debugger;
    this.empservice.getTax(forminfo.value).subscribe((data)=>{console.log(data)});
  }*/
t;
  calculateTax(id:number)
  {
    console.log(id);
 
    debugger;
    this.empservice.getTax(id).subscribe((data)=>{this.Taxamount=data});
 //this.t=this.Taxamount;

  }
}
