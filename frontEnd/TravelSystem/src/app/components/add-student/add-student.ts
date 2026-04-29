import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { Teacher } from '../../service/teacher';
import { Student } from '../../models/student.model';
import { StudentLocationUpdate } from '../../models/location.model';

@Component({
  selector: 'app-add-student',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './add-student.html',
  styleUrl: './add-student.css'
})
export class AddStudent implements OnInit {
  private teacherService = inject(Teacher);
  private route = inject(ActivatedRoute);
  private router = inject(Router);

  // שימוש במודל Student שהגדרת
  studentData: any = {
    personalId: '',
    fullName: '',
    classGroup: ''
  };

  // שימוש במבנה של StudentLocationUpdate מהמודל שלך
  locationData: StudentLocationUpdate = {
    id: '',
    geoCoordinates: {
      longitude: { degrees: '', minutes: '', seconds: '' },
      latitude: { degrees: '', minutes: '', seconds: '' }
    },
    timestamp: ''
  };

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      if (params['class']) {
        this.studentData.classGroup = params['class'];
      }
    });
  }

  saveStudent() {
    // עדכון ה-ID במיקום שיהיה זהה לתלמידה
    this.locationData.id = this.studentData.personalId;
    this.locationData.timestamp = new Date().toISOString();

    // שמירת תלמידה ולאחר מכן עדכון מיקום דרך ה-Service
    this.teacherService.registerStudent(this.studentData).subscribe({
      next: () => {
        this.teacherService.updateLocation(this.locationData).subscribe({
          next: () => {
            alert('התלמידה והמיקום נוספו בהצלחה!');
            this.goBack();
          },
          error: (err) => console.error('שגיאה בעדכון מיקום:', err)
        });
      },
      error: (err) => console.error('שגיאה ברישום תלמידה:', err)
    });
  }

  goBack() {
    this.router.navigate(['/map'], { queryParamsHandling: 'preserve' });
  }
}