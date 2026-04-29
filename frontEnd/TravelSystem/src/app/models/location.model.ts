  export interface StudentLocation {
  id: number;
  Latitude: number;
  Longitude: number;
}

export interface DMSCoordinates {
  degrees: string;
  minutes: string;
  seconds: string;
}

export interface StudentLocationUpdate {
  id: string; 
  geoCoordinates: {
    longitude: DMSCoordinates;
    latitude: DMSCoordinates;
  };
  timestamp: string;
}
