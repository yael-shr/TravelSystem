import { Component, inject, OnInit, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Map } from './components/map/map';
import { StudentList } from './components/student-list/student-list';
import { Teacher } from './service/teacher'; 

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [Map, StudentList],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {
  allStudents = signal<any[]>([]);
  allLocations = signal<any[]>([]);
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
          Latitude: loc?.latitude || loc?.Latitude,
          Longitude: loc?.longitude || loc?.Longitude
        };
      });

      console.log("All Students with Locations:", enrichedStudents);
      this.allStudents.set(enrichedStudents);
    });
  });
}
}