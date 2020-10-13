import { Component, OnInit } from '@angular/core';
import { CheckTokenService } from '../_services/checkToken.service';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.scss']
})
export class HomepageComponent implements OnInit {

  tipo = null;

  constructor(private checkToken: CheckTokenService) { }

  ngOnInit(): void {
    this.tipo = this.checkToken.getTipo();
  }

}
