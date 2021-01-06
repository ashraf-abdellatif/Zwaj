import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { route } from '../routes';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  /**
   *
   */
  constructor(private router: Router) {
  }
  canActivate(): boolean  {
    if (localStorage.getItem('token') != null) {
    return true;
    }
    this.router.navigate(['/home']);
    return false;
  }
}
