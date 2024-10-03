import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmployeesComponent } from './employees/employees.component';
import { AddEditEmployeeComponent } from './employees/add-edit-employee/add-edit-employee.component';
import { ListEmployeesComponent } from './employees/list-employees/list-employees.component';
import { ApiService } from './services/api.service';
import { BsModalService, ModalModule } from 'ngx-bootstrap/modal';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [
    AppComponent,
    EmployeesComponent,
    AddEditEmployeeComponent,
    ListEmployeesComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule,
    ToastrModule.forRoot({
      enableHtml: true
    }),
    ModalModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [ApiService, BsModalService],
  bootstrap: [AppComponent]
})
export class AppModule { }
