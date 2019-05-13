import { Component } from '@angular/core';
import { AuthService } from '../services/auth_services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  model: any = {};
  isExpanded = false;
  errorLogIn = false;

  constructor(public authService: AuthService, private router: Router) { }

  ngOnInit() {
  }

  login(): void{
    this.authService.login(this.model).subscribe(next => {
      this.router.navigate(['/insurance']);
    }, error => {
      this.errorLogIn = true;   
    });
  }

  loggedIn(): boolean {
    return this.authService.loggedIn();
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/home']);
  }

  collapse(): void {
    this.isExpanded = false;
  }

  toggle(): void {
    this.isExpanded = !this.isExpanded;
  }

  onRegisterClick(): void{
    this.router.navigate(['/register']);
  }

  isAdmin(): boolean {
    return this.authService.isAdmin();
  }
}
