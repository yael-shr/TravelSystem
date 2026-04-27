import { Component, input , OnInit } from '@angular/core';
import { GoogleMapsModule, MapMarker } from '@angular/google-maps';
import { environment } from '../../../environments/environments';

@Component({
  selector: 'app-map',
  standalone: true,
  imports: [GoogleMapsModule, MapMarker],
  templateUrl: './map.html',
  styleUrl: './map.css'
})
export class Map implements OnInit {
  allStudents = input<any[]>([]); 
  apiLoaded = false;
  center: any = { lat: 32.066, lng: 34.8222 };  zoom = 13;

   ngOnInit() {
     this.loadGoogleMapsApi();
  
    }
  loadGoogleMapsApi() {
    // בודקים אם ה-API כבר נטען כדי למנוע טעינות כפולות
    if (window.google && window.google.maps) {
       this.apiLoaded = true;
      return;}
    const script = document.createElement('script');
    // כאן אנחנו משתמשים במפתח מהסביבה!
    script.src = `https://maps.googleapis.com/maps/api/js?key=${environment.googleMapsApiKey}`;
    script.async = true;
    script.defer = true;
    script.onload = () => {
      this.apiLoaded = true;
    };
    document.head.appendChild(script);
  }

}