import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login';
import { Map } from './components/map/map'; 
import { AddStudent } from './components/add-student/add-student'; 
import { RegisterTeacher } from './components/register-teacher/register-teacher';

export const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'add-student', component: AddStudent },
  { path: 'map', component: Map }, 
  { path: 'register-teacher', component: RegisterTeacher },
  { path: '**', redirectTo: '' } 
];