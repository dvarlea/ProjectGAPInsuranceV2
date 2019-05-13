import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { IInsurance } from '../interfaces/Iinsurance';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InsuranceService {
  // properties
  baseUrl: string;
  decodedToken: any;

  constructor(private http: HttpClient, @Inject('BASE_URL') url: string, private router: Router) {
    this.baseUrl = url.concat('api/Insurance/');;
  }

  getInsurances(): Observable<IInsurance[]> {
    return this.http.get<IInsurance[]>(this.baseUrl + localStorage.getItem('user') + '/userId');
  }

  deleteInsurance(insurance: IInsurance): Observable<boolean> {
    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      }),
      body: insurance
    }
    return this.http.delete<boolean>(this.baseUrl + localStorage.getItem('user') + '/userId', options);
  }
}
