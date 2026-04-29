import { inject, Injectable, signal } from '@angular/core';
import { HttpClient, provideHttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {  StudentLocationUpdate } from '../models/location.model';



@Injectable({
  providedIn: 'root',
})
export class Teacher {
  private http = inject(HttpClient);

  studentsSignal = signal<any[]>([]);

  private teacherUrl = 'https://localhost:7109/api/Teachers';
  private studentUrl = 'https://localhost:7109/api/Students';
  private locationUrl = 'https://localhost:7109/api/Locations';
  constructor() { }

  getStudentsByClass(className: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.studentUrl}/group/${className}`);
  }

  getAllStudents(): Observable<any[]> {
    return this.http.get<any[]>(`${this.studentUrl}/all`);
  }
  
  getAllLocations(students : any[]): Observable<any[]> {
    return this.http.post<any[]>(`${this.locationUrl}/all`, students );
  }
  getLastLocation(studentId: string): Observable<any> {
    return this.http.get<any>(`${this.locationUrl}/id/${studentId}`);
  }

  getAllTeachers(): Observable<any[]> {
    return this.http.get<any[]>(`${this.teacherUrl}/all`);
  }

  getTeachersById(teacherId : string): Observable<any[]> {
    return this.http.get<any[]>(`${this.teacherUrl}/id/${teacherId}`);
  }

  getStudentsById(studentId : string): Observable<any[]> {
    return this.http.get<any[]>(`${this.studentUrl}/id/${studentId}`);
  }
  
  registerStudent(studentData: any): Observable<any> {
 
  const payload = {
    personalId: studentData.personalId,
    fullName: studentData.fullName,
    classGroup: studentData.classGroup
  };
  return this.http.post(`${this.studentUrl}/add`, payload);
}

  registerTeacher(teacherData: any): Observable<any> {
    return this.http.post(`${this.teacherUrl}/add`, teacherData);
  }

  updateLocation(location: StudentLocationUpdate): Observable<any> {
  return this.http.post(`${this.locationUrl}/update`, location);
}
}
