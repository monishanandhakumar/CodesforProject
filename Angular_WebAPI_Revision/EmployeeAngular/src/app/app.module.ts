import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import{HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmployeeService } from 'src/Services/employeeService';
import { EmployeecrudComponent } from './employeecrud/employeecrud.component';
import { DepartmentcrudComponent } from './departmentcrud/departmentcrud.component';
import{FormsModule} from '@angular/forms';
import { EmploginComponent } from './emplogin/emplogin.component'
import { LoginService } from 'src/Services/loginService';
import { HomeComponent } from './home/home.component';
import { GetempbydeptComponent } from './getempbydept/getempbydept.component';
import { TaxcalculationComponent } from './taxcalculation/taxcalculation.component';
import { AdminlayoutComponent } from './adminlayout/adminlayout.component';
import { UserlayoutComponent } from './userlayout/userlayout.component';
import { RegisterComponent } from './register/register.component';
import { RegisterService } from 'src/Services/registerService';

@NgModule({
  declarations: [
    AppComponent,
    EmployeecrudComponent,
    DepartmentcrudComponent,
    EmploginComponent,
    HomeComponent,
    GetempbydeptComponent,
    TaxcalculationComponent,
    AdminlayoutComponent,
    UserlayoutComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,HttpClientModule,FormsModule
  ],
  providers: [EmployeeService,LoginService,RegisterService],
  bootstrap: [AppComponent]
})
export class AppModule { }
