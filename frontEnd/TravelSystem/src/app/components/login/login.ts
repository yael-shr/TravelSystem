import { Component, signal , inject} from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { Teacher } from '../../service/teacher';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class LoginComponent {
  idNumber = '';
  errorMessage = '';
  private teacherService = inject(Teacher);


  constructor(private router: Router) {}

 onLogin(role: string) {
  this.errorMessage = ''; 

  if (!this.idNumber) {
    this.errorMessage = 'אנא הזיני מספר זיהוי';
    return;
  }

  if (role === 'teacher') {
    this.teacherService.getAllTeachers().subscribe((teachers: any[]) => {
      const isExist = teachers.some(t => t.personalId === this.idNumber || t.PersonalId === this.idNumber);
      
      if (isExist) {
        this.navigateToMap(role);
      } else {
        this.errorMessage = 'מורה זו אינה רשומה במערכת';
        alert(this.errorMessage);
      }
    });
  } else if (role === 'parent') {
    this.teacherService.getAllStudents().subscribe((students: any[]) => {
      const isExist = students.some(s => s.personalId === this.idNumber || s.PersonalId === this.idNumber);
      
      if (isExist) {
        this.navigateToMap(role);
      } else {
        this.errorMessage = 'תלמידה זו אינה רשומה במערכת';
        alert(this.errorMessage);
      }
    });
  }
}

private navigateToMap(role: string) {
  this.router.navigate(['/map'], {
    queryParams: { role: role, id: this.idNumber }
  });
}


goToTeacherRegister() {
  this.router.navigate(['/register-teacher']);
}
}