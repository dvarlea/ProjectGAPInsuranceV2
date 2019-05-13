import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { InsurancesComponent } from './insurance/insurances.component';
import { RegisterComponent } from './register/register.component';
import { NonAdminGuard } from './guards/non-admin.guard';
import { InsuranceDataComponent } from './insurance/insurance-data.component';
import { ConvertRisksPipe } from './shared/risks.pipe';
import { NonAddGuard } from './guards/non-add.guard';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    InsurancesComponent,
    RegisterComponent,
    InsuranceDataComponent,
    ConvertRisksPipe
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: 'home', component: HomeComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'insurance', component: InsurancesComponent, canActivate: [NonAdminGuard] },
      { path: 'insurance/add', component: InsuranceDataComponent, canActivate: [NonAddGuard] },
      { path: '**', component: HomeComponent, pathMatch: 'full' },
      { path: '', component: HomeComponent, pathMatch: 'full' }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }