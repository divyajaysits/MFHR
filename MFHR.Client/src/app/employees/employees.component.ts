import { Component } from '@angular/core';
import { Employee, Resp } from '../dto/dto';
import { ApiService } from '../services/api.service';
import { ToastrService } from 'ngx-toastr';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { AddEditEmployeeComponent } from './add-edit-employee/add-edit-employee.component';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrl: './employees.component.css'
})
export class EmployeesComponent {

  modalRef: BsModalRef | undefined;

  SelectedEmployee: Employee = new Employee();
  EmployeeList: Employee[] = [];
  modalOptions: ModalOptions = {
    backdrop: true,
    ignoreBackdropClick: false,
    class: 'bg-white',
    id: 0,
    keyboard: true,
    focus: true,
    show: true,
    animated: true,
    initialState: undefined
  };

  constructor(
    private apiService: ApiService,
    private toastr: ToastrService,
    private modalService: BsModalService,
  ) {

  }

  async ngOnInit(): Promise<void> {

    await this.apiService.GetAllActiveEmployees(20).subscribe(
      (data: Resp) => {
        if (data.success) {
          if (data.entity) {
            this.EmployeeList = data.entity;
          } else {
            this.EmployeeList = [];
          }
        } else {
          this.toastr.error('', data.message, {
            timeOut: 6000, positionClass: "toast-top-right", messageClass: "messagetoast"
          });
          this.EmployeeList = [];
        }
      },
      err => {
        this.toastr.error('', err, {
          timeOut: 6000, positionClass: "toast-top-right", messageClass: "messagetoast"
        });
      }
    );
  }

  onRowClicked(emp:Employee) {
    if (emp) {
      localStorage.setItem("SelectedEmployee", emp.iD.toString()); 
      this.modalRef = this.modalService.show(AddEditEmployeeComponent, this.modalOptions);
    } else {
      console.log("emp is null");
    }
  }

 
}
