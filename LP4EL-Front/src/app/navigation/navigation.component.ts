import { Component, OnInit } from '@angular/core';
import { CheckTokenService } from '../_services/checkToken.service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent implements OnInit {

  tipo: String = null;

  constructor(private checkToken: CheckTokenService) { }

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
    console.log('logged out successfully');
  }
}
