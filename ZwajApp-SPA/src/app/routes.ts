import { Routes } from '@angular/router';
import { ChatComponent } from './chat/chat.component';
import { HomeComponent } from './home/home.component';
import { ListComponent } from './list/list.component';
import { MembersComponent } from './members/members.component';
import { AuthGuard } from './_gaurd/auth.guard';


export const route: Routes = [
{ path: '', component: HomeComponent },
{ path: 'member', component: MembersComponent , canActivate:[AuthGuard] },
{ path: 'list', component: ListComponent },
{ path: 'chat', component: ChatComponent },
{ path: '**', component: HomeComponent },
] ;
