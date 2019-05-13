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

  addInsurance(): void{
    if(!this.validate()){
      return;
    }

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
      alert('Insurance added successfully');
    }, error => alert('An error ocurred while adding your insurance'));
  }
}

enum Risks {
  Alto = 1,
  MedioAlto,
  Medio,
  Bajo
}
