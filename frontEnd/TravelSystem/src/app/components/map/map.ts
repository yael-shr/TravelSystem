import { Component, input } from '@angular/core';
import { GoogleMapsModule, MapMarker } from '@angular/google-maps';

@Component({
  selector: 'app-map',
  standalone: true,
  imports: [GoogleMapsModule, MapMarker],
  templateUrl: './map.html',
  styleUrl: './map.css'
})
export class Map {
  // השורה הזו יוצרת את ה"כניסה" לנתונים מהאבא
  allStudents = input<any[]>([]); 
  
  center: google.maps.LatLngLiteral = { lat: 31.7683, lng: 35.2137 };
  zoom = 15;
}