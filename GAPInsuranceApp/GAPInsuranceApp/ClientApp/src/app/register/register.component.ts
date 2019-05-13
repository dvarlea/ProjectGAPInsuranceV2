import { Component } from '@angular/core';
import { AuthService } from '../services/auth_services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  model: any = {};

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  register() {
    this.model.role = 0//admin harcoded, admin user in the future
    this.authService.register(this.model).subscribe(() => {
      this.model = {};
      alert('User registered successfully, please Log in');
    }, () => {
      alert('An error ocurred, User already exists');
    });
  }
}
