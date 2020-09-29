import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { NavigationComponent } from './navigation/navigation.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { CustomMdcModule } from './mdc.module';
import { FormsModule } from '@angular/forms';
import { AuthService } from './_services/auth.service';

const appRoutes: Routes = [
   { path: 'login', component: LoginComponent },
   { path: 'signup', component: SignupComponent}
];

@NgModule({
   declarations: [
      AppComponent,
      UserComponent,
      NavigationComponent,
      LoginComponent,
      SignupComponent,
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      RouterModule.forRoot(appRoutes),
      CustomMdcModule,
      FormsModule
   ],
   providers: [
      AuthService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
