import { Component, OnInit } from '@angular/core';
import { InsuranceService } from '../../services/insurance.service';

@Component({
  selector: 'app-insurance-data',
  templateUrl: './insurance-data.component.html',
  styleUrls: ['./insurance-data.component.css']
})
export class InsuranceDataComponent implements OnInit {
  model: any = {};

  constructor(private insuService: InsuranceService) { }

  ngOnInit() {
    this.model.risk = 1;
  }

  addInsurance(): void{
    let insurance = {
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
    this.insuService.addInsurance(insurance).subscribe(result => {
      //success
      this.model={};
    }, error => console.error(error));
  }
}
