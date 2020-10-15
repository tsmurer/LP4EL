import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CheckTokenService } from '../_services/checkToken.service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent implements OnInit {

  tipo: String = null;

  constructor(private checkToken: CheckTokenService, private router: Router) { }

  ngOnInit() {
    console.log(this.checkToken.getTipo());
    this.tipo = this.checkToken.getTipo();
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token;
  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigateByUrl('/');
    console.log('logged out successfully');
  }
}
