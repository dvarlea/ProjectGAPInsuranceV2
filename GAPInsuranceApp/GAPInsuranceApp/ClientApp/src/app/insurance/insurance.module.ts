import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InsuranceDataComponent } from './insuranceAdd/insurance-data.component';
import { InsurancesComponent } from './insurances.component';
import { InsuranceEditComponent } from './insuranceEdit/insurance-edit.component';
import { RouterModule } from '@angular/router';
import { NonAdminGuard } from '../guards/non-admin.guard';
import { NonAddGuard } from '../guards/non-add.guard';
import { ConvertRisksPipe } from '../shared/risks.pipe';
import { FormsModule }   from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild([
      { path: 'insurance', component: InsurancesComponent, canActivate: [NonAdminGuard] },
      { path: 'insurance/add', component: InsuranceDataComponent, canActivate: [NonAddGuard] },
      { path: 'insurance/edit', component: InsuranceEditComponent, canActivate: [NonAddGuard] }
    ])
  ],
  declarations: [
    InsurancesComponent,
    InsuranceDataComponent,
    InsuranceEditComponent,
    ConvertRisksPipe
  ]
})
export class InsuranceModule { }

