import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login';
import { Map } from './components/map/map'; 
import { AddStudent } from './components/add-student/add-student'; // ודאי ייבוא תקין

export const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'add-student', component: AddStudent },
  { path: 'map', component: Map }, // שינינו ל-m קטנה כדי שיתאים לניווט
  { path: '**', redirectTo: '' } 
];