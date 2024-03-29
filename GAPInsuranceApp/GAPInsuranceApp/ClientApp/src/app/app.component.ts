import { Component } from '@angular/core';
import { AuthService } from './services/auth_services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  constructor(private authService: AuthService){}

  ngOnDestroy(): void {
    this.authService.logout();
  }
}
