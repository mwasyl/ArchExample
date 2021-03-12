import { Injectable } from '@angular/core';
import { Trip } from './trip';
import { TRIPS } from './mock-trips';
import { Observable, of } from 'rxjs';
import { Guid } from 'guid-typescript';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TripService {

  private tripsUrl = 'https://archexampletrip.azurewebsites.net/api/Travels';  // URL to web api

  constructor(
    private http: HttpClient) { }

  getTrips(): Observable<Trip[]> {
    return this.http.get<Trip[]>(this.tripsUrl);
  }

  getTrip(id: Guid): Observable<Trip> {
    return this.http.get<Trip>(this.tripsUrl+"/"+id)
  }
}
