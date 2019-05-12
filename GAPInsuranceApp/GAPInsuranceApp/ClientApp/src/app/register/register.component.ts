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
    this.model.role = 1;//admin
    this.authService.register(this.model).subscribe(() => {
      this.model = null;
    }, error => {
      alert('An error ocurred');
    });
  }
}
