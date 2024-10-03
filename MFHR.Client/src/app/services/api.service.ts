
import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { Router } from '@angular/router';
import { Resp } from '../dto/dto';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  _baseUrl =  "https://localhost:7136/";

  constructor(private http: HttpClient, private router: Router) { }

  CreateNewEmployee(reqobj: any): Observable<Resp> {
    return this.http
      .post<Resp>(
        this._baseUrl + 'api/Employee/CreateNewEmployee', reqobj);
  }


  UpdateEmployee(reqobj: any): Observable<Resp> {
    return this.http
      .post<Resp>(
        this._baseUrl + 'api/Employee/UpdateEmployee', reqobj);
  }


  GetByEmployeeId(id: number): Observable<Resp> {
    return this.http
      .get<Resp>(
        this._baseUrl + 'api/Employee/GetByEmployeeId?id'+id);
  }

  GetAllActiveEmployees(rowcount: number): Observable<Resp> {
    return this.http
      .get<Resp>(
        this._baseUrl + 'api/Employee/GetAllActiveEmployees?rows=' + rowcount);
  }


}
