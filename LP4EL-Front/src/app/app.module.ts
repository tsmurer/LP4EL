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
import { HomepageComponent } from './homepage/homepage.component';
import { HemocentrosComponent } from './hemocentros/hemocentros.component';
import { PontosComponent } from './pontos/pontos.component';
import { LojaComponent } from './loja/loja.component';
import { DoacaoComponent } from './doacao/doacao/doacao.component';

const appRoutes: Routes = [
   { path: '', component: HomepageComponent},
   { path: 'conta', component: PontosComponent},
   { path: 'doacao', component: DoacaoComponent},
   { path: 'loja', component: LojaComponent},
   { path: 'hemocentros', component: HemocentrosComponent},
   { path: 'login', component: LoginComponent },
   { path: 'signup', component: SignupComponent},
];

@NgModule({
   declarations: [
      DoacaoComponent,
      AppComponent,
      UserComponent,
      NavigationComponent,
      LoginComponent,
      SignupComponent,
      HomepageComponent,
      HemocentrosComponent,
      PontosComponent,
      LojaComponent
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
