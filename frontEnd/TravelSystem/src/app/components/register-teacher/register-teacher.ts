import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { Teacher } from '../../service/teacher';

@Component({
  selector: 'app-register-teacher',
  standalone: true,
  imports: [FormsModule, CommonModule], // קריטי להצגת הטופס
  templateUrl: './register-teacher.html',
  styleUrl: './register-teacher.css'
})
export class RegisterTeacher {
  private teacherService = inject(Teacher);
  private router = inject(Router);

  teacherData = {
    fullName: '',
    personalId: '',
    classGroup: ''
  };

  saveTeacher() {
    this.teacherService.registerTeacher(this.teacherData).subscribe({
      next: () => {
        alert('המורה נרשמה בהצלחה!');
        this.router.navigate(['/']); // חזרה ללוגין
      },
      error: (err) => {
        console.error(err);
        alert('שגיאה ברישום המורה');
      }
    });
  }

  goBack() {
    this.router.navigate(['/']);
  }
}