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
      console.log('registration successful');
      this.router.navigate(['/']);
    }, error => {
      console.log(error);
    });
  }

  cancel() {
    console.log('cancelled');
  }
}
