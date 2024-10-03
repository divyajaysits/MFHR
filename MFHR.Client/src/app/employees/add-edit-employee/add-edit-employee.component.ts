import { Component } from '@angular/core';
import { Employee, Resp } from '../../dto/dto';
import { ApiService } from '../../services/api.service';
import { ToastrService } from 'ngx-toastr';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-add-edit-employee',
  templateUrl: './add-edit-employee.component.html',
  styleUrl: './add-edit-employee.component.css'
})
export class AddEditEmployeeComponent {

  SelectedEmployee = new Employee();
  constructor(
    private apiService: ApiService,
    private toastr: ToastrService,
    public modalRef: BsModalRef,
  ) {
    
  }


  async ngOnInit(): Promise<void> {
    var t = localStorage.getItem("SelectedEmployee");
    if (t != "") {

    }
  }

  async getByEmployeeId(id:number) {
    await this.apiService.GetByEmployeeId(id).subscribe(
      (data: Resp) => {
        if (data.success) {
          if (data.entity) {
            this.SelectedEmployee = data.entity;
          } else {
            this.SelectedEmployee = new Employee();
          }
        } else {
          this.toastr.error('', data.message, {
            timeOut: 6000, positionClass: "toast-top-right", messageClass: "messagetoast"
          });
          this.SelectedEmployee = new Employee();
        }
      },
      err => {
        this.toastr.error('', err, {
          timeOut: 6000, positionClass: "toast-top-right", messageClass: "messagetoast"
        });
      }
    );
  }

  saveUser() {

    //Validation

    if (this.SelectedEmployee.iD == 0) {
      this.apiService.CreateNewEmployee(this.SelectedEmployee).subscribe((data: any) => {
        if (data.success) {
          this.toastr.success('', data.message, {
            timeOut: 6000, positionClass: "toast-top-right", messageClass: "messagetoast"
          });
          this.modalRef.hide();
        } else {
          this.toastr.error('', data.message, {
            timeOut: 6000, positionClass: "toast-top-right", messageClass: "messagetoast"
          });
        }
      },
        (err: any) => {
          this.toastr.error('', 'Sorry an error occured', {
            timeOut: 6000, positionClass: "toast-top-right", messageClass: "messagetoast"
          });
        });
    } else {
      this.apiService.UpdateEmployee(this.SelectedEmployee).subscribe((data: any) => {
        if (data.success) {
          this.toastr.success('', data.message, {
            timeOut: 6000, positionClass: "toast-top-right", messageClass: "messagetoast"
          });
          this.modalRef.hide();
        } else {
          this.toastr.error('', data.message, {
            timeOut: 6000, positionClass: "toast-top-right", messageClass: "messagetoast"
          });
        }
      },
        (err: any) => {
          this.toastr.error('', 'Sorry an error occured', {
            timeOut: 6000, positionClass: "toast-top-right", messageClass: "messagetoast"
          });
        });
    }
  }

  handleClose(event: any) {
    this.modalRef.hide()
  }
}
