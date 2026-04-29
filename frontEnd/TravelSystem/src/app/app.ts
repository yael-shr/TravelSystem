import { Component, inject, OnInit, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Teacher } from './service/teacher'; 

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet], // השארנו רק את ה-Outlet!
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {
  private teacherService = inject(Teacher);

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    // טוענים את הנתונים לתוך ה-Service כדי שהמפה תוכל לגשת אליהם מכל מקום
    this.teacherService.getAllStudents().subscribe((students: any[]) => {
      this.teacherService.getAllLocations(students).subscribe((locations: any[]) => {
        const enrichedStudents = students.map(student => {
          const loc = locations.find(l => l.personalId === student.personalId || l.PersonalId === student.personalId);
          return {
            ...student,
            // Google Maps מצפה ל-lat ו-lng באותיות קטנות
            latitude: loc?.latitude || loc?.Latitude,
            longitude: loc?.longitude || loc?.Longitude
          };
        });
        // עדכון הסיגנל ב-Service (צריך להוסיף אותו ב-teacher.ts)
        this.teacherService.studentsSignal.set(enrichedStudents);
      });
    });
  }
}