import { Routes } from '@angular/router';
import { ChatComponent } from './chat/chat.component';
import { HomeComponent } from './home/home.component';
import { MemberDetailComponent } from './members/Member-Detail/Member-Detail.component';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { MemberlistComponent } from './members/memberlist/memberlist.component';
import { AuthGuard } from './_gaurd/auth.guard';


export const route: Routes = [
{ path: '', component: HomeComponent },
{ path: 'members', component: MemberlistComponent , canActivate: [AuthGuard] },
{ path: 'members/:id', component: MemberDetailComponent , canActivate: [AuthGuard] },
{ path: 'member/Edit', component: MemberEditComponent , canActivate: [AuthGuard] },
{ path: 'chat', component: ChatComponent },
{ path: '**', component: HomeComponent },
] ;
