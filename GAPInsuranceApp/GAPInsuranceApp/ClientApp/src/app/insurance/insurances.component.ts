import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IInsurance } from '../interfaces/Iinsurance';
import { AuthService } from '../services/auth_services/auth.service';
import { InsuranceService } from '../services/insurance.service';
import { Router } from '@angular/router';

@Component({
  templateUrl: './insurances.component.html',
  styleUrls: ['./insurances.component.css']
})
export class InsurancesComponent {
  public insurances: IInsurance[];
  public baseUrl: string;

  constructor(private authService: AuthService, private insuService: InsuranceService,
    private http: HttpClient, @Inject('BASE_URL') url: string, private router: Router) {
    this.baseUrl = url;

  }

  ngOnInit() {
    this.getInsuraces();
  }

  isAdmin(): boolean {
    return this.authService.isAdmin();
  }

  deleteInsurance(insurance: IInsurance): void {
    if (confirm("Are you sure you want to delete this Insurance?")) {
      this.insuService.deleteInsurance(insurance).subscribe(() => {
        this.getInsuraces();
      }, () => alert('An error ocurred while deleting your insurance'));
    }
  }

  editInsurance(insurance: IInsurance): void {
    this.insuService.setInsuranceUpdate(insurance);
    this.router.navigate(['/insurance/edit']);
  }

  getInsuraces(): void {
    this.insuService.getInsurances().subscribe(result => {
      this.insurances = result;
    }, error => console.error(error));
  }
}

