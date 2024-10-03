import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { ToastrService } from 'ngx-toastr';
import { Employee, Resp } from '../../dto/dto';


@Component({
  selector: 'app-list-employees',
  templateUrl: './list-employees.component.html',
  styleUrl: './list-employees.component.css'
})
export class ListEmployeesComponent {

  @Input() employees: Employee[] = [];
  @Output() selectedEmployee: EventEmitter<Employee> = new EventEmitter<Employee>();

  editEmployee(emp:Employee) {
    this.selectedEmployee.emit(emp);
  }

  async ngOnInit(): Promise<void> {

    
  }
}
