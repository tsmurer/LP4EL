import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
  model: any = {};

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
  }

  register() {
    this.authService.register(this.model).subscribe(() => {
      alert('Registro feito com sucesso');
      this.router.navigate(['/']);
      //const loginObject = {name: this.model.name, password: this.model.password}

    }, error => {
      console.log(error);
      alert('Checar informações!');
      console.log(this.model);
    });
  }

  cancel() {
    console.log('cancelled');
  }
}
