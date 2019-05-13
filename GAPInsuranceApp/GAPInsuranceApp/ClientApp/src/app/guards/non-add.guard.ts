import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth_services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class NonAddGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router){

  }
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
      if(!this.authService.loggedIn()){
        this.router.navigate(['/home']);
        return false;
      }
      if(!this.authService.isAdmin()){
        this.router.navigate(['/insurance']);
        return false;
      }
    return true;
  }
}
