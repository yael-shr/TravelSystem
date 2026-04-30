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
  alerts = signal<string[]>([]);

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
      this.refreshSubscription = interval(3000).subscribe(() => {
        this.refreshLocationsFromServer(); 
      });
    });

    this.loadGoogleMapsApi();
  }

 checkStudentsLocation() {
  navigator.geolocation.getCurrentPosition((position) => {
    const teacherLat = position.coords.latitude;
    const teacherLon = position.coords.longitude;

    // 1. ניקוי רשימת האזהרות הישנה לפני בדיקה חדשה
    // או לחילופין: ניהול רשימה חכמה שלא מוסיפה כפילויות
    let newAlerts: string[] = [];

    this.displayStudents().forEach(student => {
      const distance = this.calculateDistance(
        teacherLat, teacherLon, 
        student.latitude, student.longitude
      );

      if (distance > 500) {
        const msg = `אזהרה: ${student.fullName} רחוקה (${(distance/1000).toFixed(1)} ק"מ)`;
        newAlerts.push(msg);
      }
    });

    // 2. עדכון ה-Signal עם הרשימה העדכנית בלבד (זה ימחק הודעות ישנות ויוסיף חדשות)
    this.alerts.set(newAlerts);
  });
}

  // נוסחת Haversine לחישוב מרחק במטרים
  calculateDistance(lat1: number, lon1: number, lat2: number, lon2: number): number {
    const R = 6371000; // רדיוס כדור הארץ במטרים
    const dLat = (lat2 - lat1) * Math.PI / 180;
    const dLon = (lon2 - lon1) * Math.PI / 180;
    const a = 
      Math.sin(dLat / 2) * Math.sin(dLat / 2) +
      Math.cos(lat1 * Math.PI / 180) * Math.cos(lat2 * Math.PI / 180) * 
      Math.sin(dLon / 2) * Math.sin(dLon / 2);
    const c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
    return R * c;
  }

  showAlert(name: string, distance: number) {
  const msg = `אזהרה: ${name} רחוקה (${(distance/1000).toFixed(1)} ק"מ)`;
  this.alerts.update(prev => [...prev, msg]);
  
  // הסרת ההתראה אחרי 10 שניות כדי לא להעמיס
  setTimeout(() => {
    this.alerts.update(prev => prev.filter(m => m !== msg));
  }, 10000);
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
    if (this.userRole() === 'teacher') {
  this.checkStudentsLocation();
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