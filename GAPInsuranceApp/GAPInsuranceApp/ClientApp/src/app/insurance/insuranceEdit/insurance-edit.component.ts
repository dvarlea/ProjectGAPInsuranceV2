import { Component, OnInit } from '@angular/core';
import { InsuranceService } from '../../services/insurance.service';
import { IInsurance } from 'src/app/interfaces/Iinsurance';
import { Router } from '@angular/router';
import { Risks } from 'src/app/shared/risks';

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

  validate(): boolean{
    if(this.model.coverageAmt > 50 && this.model.risk == Risks.Alto){
      alert('La covertura no puede ser superior al 50% en caso de riesgo alto');
      return false;
    }
    if(this.model.coverageAmt > 100 || this.model.coverageAmt < 0 ){
      alert('La covertura debe estar entre 0 y 100%');
      return false;
    }
    return true;
  }

  editInsurance(): void{
    if(!this.validate()){
      return;
    }
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
