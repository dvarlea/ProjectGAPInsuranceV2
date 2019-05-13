import { Component, OnInit } from '@angular/core';
import { InsuranceService } from '../../services/insurance.service';
import { IInsurance } from 'src/app/interfaces/Iinsurance';
import { Router } from '@angular/router';

@Component({
  selector: 'app-insurance-edit',
  templateUrl: './insurance-edit.component.html',
  styleUrls: ['./insurance-edit.component.css']
})
export class InsuranceEditComponent implements OnInit {
  model: any = {};

  constructor(private insuService: InsuranceService, private router: Router) { }

  ngOnInit() {
    this.model = this.insuService.getInsuranceUpdate();
    this.model.coverageAmt = this.model.coverageAmt*100;
  }

  editInsurance(): void{
    let insurance: IInsurance = {
      id: this.model.id,
      clientId: this.model.clientId,
      name: this.model.name,
      description: this.model.description,
      coverages: this.model.coverages,
      coverageAmt: this.model.coverageAmt/100,
      begining: this.model.begining,
      timePeriod: this.model.timePeriod,
      price: this.model.price,
      risk: +this.model.risk
    }
    this.insuService.updateInsurance(insurance).subscribe(result => {
      this.model={};
      this.router.navigate(['/insurance']);
    }, error => console.error(error));
  }

}
