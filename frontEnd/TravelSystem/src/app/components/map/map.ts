import { Component, OnInit, OnDestroy, inject, signal, computed } from '@angular/core';
import { interval, Subscription } from 'rxjs';
import { GoogleMapsModule } from '@angular/google-maps';
import { environment } from '../../../environments/environments';
import { ActivatedRoute, Router } from '@angular/router';
import { Teacher } from '../../service/teacher';

@Component({
  selector: 'app-map',
  standalone: true,
  imports: [GoogleMapsModule], 
  templateUrl: './map.html',
  styleUrl: './map.css'
})
export class Map implements OnInit, OnDestroy {
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  private teacherService = inject(Teacher);
  private refreshSubscription?: Subscription;

  apiLoaded = signal(false); 
  userRole = signal<string | null>(null);
  selectedStudentId = signal<string | null>(null);
  teacherClass = signal<string | null>(null);
  currentStudent = signal<any | null>(null);

  displayStudents = signal<any[]>([]); 

  center: google.maps.LatLngLiteral = { lat: 32.066, lng: 34.8222 };
  zoom = 13;

  filteredStudents = computed(() => this.displayStudents());

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      const role = params['role'];
      const id = params['id'];
      
      this.userRole.set(role);
      this.selectedStudentId.set(id);
      this.displayStudents.set([]); 
      this.refreshLocationsFromServer();

      if (this.refreshSubscription) {
        this.refreshSubscription.unsubscribe();
      }
      this.refreshSubscription = interval(30000).subscribe(() => {
        this.refreshLocationsFromServer(); 
      });
    });

    this.loadGoogleMapsApi();
  }

  refreshLocationsFromServer() {
    const currentRole = this.userRole();
    const currentId = this.selectedStudentId();
    const currentClass = this.teacherClass();

    if (!currentRole || !currentId) return;

    console.log('מתבצע סנכרון אוטומטי מול השרת...');

    if (currentRole === 'teacher') {
      this.teacherService.getTeachersById(currentId).subscribe((teacher: any) => {
        const teacherData = Array.isArray(teacher) ? teacher[0] : teacher;
        const className = teacherData?.classGroup || teacherData?.class;
        this.teacherClass.set(className);

        if (className) {
          this.teacherService.getStudentsByClass(className).subscribe(students => {
            this.teacherService.getAllLocations(students).subscribe(locations => {
              const enriched = students.map(s => {
                const loc = locations.find(l => l.personalId === s.personalId || l.PersonalId === s.personalId);
                return {
                  ...s,
                  latitude: loc ? Number(loc.latitude || loc.Latitude) : null,
                  longitude: loc ? Number(loc.longitude || loc.Longitude) : null
                };
              });
              this.displayStudents.set(enriched.filter(s => s.latitude && s.longitude));
            });
          });
        }
      });
    } 
    else if (currentRole === 'parent') {
      this.teacherService.getStudentsById(currentId).subscribe(student => {
        const studentData = Array.isArray(student) ? student[0] : student;
        this.currentStudent.set(studentData);
        this.teacherService.getAllLocations([studentData]).subscribe(locations => {
          const loc = locations[0];
          const updatedStudent = {
            ...studentData,
            latitude: loc ? Number(loc.latitude || loc.Latitude) : null,
            longitude: loc ? Number(loc.longitude || loc.Longitude) : null
          };
          this.displayStudents.set([updatedStudent]);
        });
      });
    }
  }

  addStudent() {
    console.log('מנווט לדף הוספת תלמידה...');
    this.router.navigate(['/add-student'], { 
      queryParams: { 
        class: this.teacherClass(), 
        role: 'teacher',
        id: this.selectedStudentId() 
      } 
    });
  }

  loadGoogleMapsApi() {
    if (window.google && window.google.maps) {
      this.apiLoaded.set(true);
      return;
    }
    const script = document.createElement('script');
    script.src = `https://maps.googleapis.com/maps/api/js?key=${environment.googleMapsApiKey}`;
    script.async = true;
    script.defer = true;
    script.onload = () => { this.apiLoaded.set(true); };
    document.head.appendChild(script);
  }

  ngOnDestroy() {
    if (this.refreshSubscription) {
      this.refreshSubscription.unsubscribe();
    }
  }
}