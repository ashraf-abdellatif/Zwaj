import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {  HttpClientModule } from '@angular/common/http';
import { NavComponent } from './Nav/Nav.component';
import {  FormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { AuthService } from './_services/Auth.service';
import { MembersComponent } from './members/members.component';
import { ListComponent } from './list/list.component';
import { ChatComponent } from './chat/chat.component';
import { Router, RouterModule } from '@angular/router';
import { route } from './routes';
import { AuthGuard } from './_gaurd/auth.guard';
@NgModule({
  declarations: [
    AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      MembersComponent,
      ListComponent,
      ChatComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(route),
  ],
  providers: [AuthService , AuthGuard ],
  bootstrap: [AppComponent]
})
export class AppModule { }
