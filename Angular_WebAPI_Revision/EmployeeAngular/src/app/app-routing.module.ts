import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminlayoutComponent } from './adminlayout/adminlayout.component';
import { DepartmentcrudComponent } from './departmentcrud/departmentcrud.component';
import { EmploginComponent } from './emplogin/emplogin.component';
import { EmployeecrudComponent } from './employeecrud/employeecrud.component';
import { GetempbydeptComponent } from './getempbydept/getempbydept.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { TaxcalculationComponent } from './taxcalculation/taxcalculation.component';
import { UserlayoutComponent } from './userlayout/userlayout.component';

const routes: Routes = [
  //default 
  {path:'',redirectTo:'/home',pathMatch:'full'},
 
  {path:'home',component:HomeComponent,
  children:[{path:'login',component:EmploginComponent},
  {path:'register',component:RegisterComponent}]},
 /*{path:'login',component:EmploginComponent},*/
 /* {path:'taxcalculator',component:TaxcalculationComponent},*/
/* {path:'empbydept',component:GetempbydeptComponent}, */
  //Adminlayout
  {path:'adminlayout',component:AdminlayoutComponent,
  children:[ {path:'deptcrud',component:DepartmentcrudComponent},
  {path:'empcrud',component:EmployeecrudComponent}]},
//userlayout
  {path:'userlayout',component:UserlayoutComponent,
  children:[{path:'taxcalculator',component:TaxcalculationComponent},
  {path:'empbydept',component:GetempbydeptComponent},
  ]}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
