import { Component, inject, OnInit, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Map } from './components/map/map';
import { Teacher } from './service/teacher'; // ודאי שהנתיב ל-Service נכון

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [Map],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {
  // 1. הגדרת ה-Signal שחסר (כאן הייתה השגיאה!)
  allStudents = signal<any[]>([]);

  // 2. הזרקת ה-Service
  private teacherService = inject(Teacher);

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    // 3. משיכת הנתונים מה-C# ועדכון ה-Signal
    this.teacherService.getAllStudents().subscribe((data: any[]) => {
      this.allStudents.set(data);
    });
  }
}