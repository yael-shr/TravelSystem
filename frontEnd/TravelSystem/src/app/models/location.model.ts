  export interface StudentLocation {
  id: number;
  Latitude: number;
  Longitude: number;
}

// מודל לקואורדינטות בפורמט DMS (Degrees, Minutes, Seconds)
export interface DMSCoordinates {
  degrees: string;
  minutes: string;
  seconds: string;
}

// מודל לנתוני מיקום כפי שנשלחים לשרת
export interface StudentLocationUpdate {
  id: string; // ה-personalId של התלמידה
  geoCoordinates: {
    longitude: DMSCoordinates;
    latitude: DMSCoordinates;
  };
  timestamp: string;
}
