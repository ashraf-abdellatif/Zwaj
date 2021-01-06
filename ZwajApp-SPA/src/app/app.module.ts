import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {  HttpClientModule } from '@angular/common/http';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { NgxGalleryModule } from 'ngx-gallery';

import { NavComponent } from './Nav/Nav.component';
import {  FormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { AuthService } from './_services/Auth.service';
import { ChatComponent } from './chat/chat.component';
import { Router, RouterModule } from '@angular/router';
import { route } from './routes';
import { AuthGuard } from './_gaurd/auth.guard';
import { UserService } from './_services/User.service';
import { MemberCardComponent } from './members/member-card/member-card.component';
import { MemberlistComponent } from './members/memberlist/memberlist.component';
import { MemberDetailComponent } from './members/Member-Detail/Member-Detail.component';
@NgModule({
  declarations: [
    AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      ChatComponent,
      MemberCardComponent,
      MemberlistComponent,
      MemberDetailComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(route),
    TabsModule.forRoot(),
    NgxGalleryModule
  ],
  providers: [AuthService , AuthGuard , UserService ],
  bootstrap: [AppComponent]
})
export class AppModule { }
