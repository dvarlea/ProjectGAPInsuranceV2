import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IInsurance } from '../interfaces/Iinsurance';
import { AuthService } from '../services/auth_services/auth.service';

@Component({
  templateUrl: './insurances.component.html',
  styleUrls: ['./insurances.component.css']
})
export class InsurancesComponent {
  public insurances: IInsurance[];
  public baseUrl: string;

  constructor(private authService: AuthService , private http: HttpClient, @Inject('BASE_URL') url: string) {
    this.baseUrl = url;
    
  }

  ngOnInit() {
    this.http.get<IInsurance[]>(this.baseUrl + 'api/Insurance/'+localStorage.getItem('user')+'/userId').subscribe(result => {
      this.insurances = result;
    }, error => console.error(error));
  }

  isAdmin(): boolean {
    return this.authService.isAdmin();
  }
}

