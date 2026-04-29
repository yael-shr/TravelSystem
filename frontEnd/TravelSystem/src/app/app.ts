import { Component, inject, OnInit, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Teacher } from './service/teacher'; 

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet], 
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {
  private teacherService = inject(Teacher);

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    this.teacherService.getAllStudents().subscribe((students: any[]) => {
      this.teacherService.getAllLocations(students).subscribe((locations: any[]) => {
        const enrichedStudents = students.map(student => {
          const loc = locations.find(l => l.personalId === student.personalId || l.PersonalId === student.personalId);
          return {
            ...student,
            latitude: loc?.latitude || loc?.Latitude,
            longitude: loc?.longitude || loc?.Longitude
          };
        });
        this.teacherService.studentsSignal.set(enrichedStudents);
      });
    });
  }
}