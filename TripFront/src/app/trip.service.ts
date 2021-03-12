import { Injectable } from '@angular/core';
import { Trip } from './trip';
import { Observable, of } from 'rxjs';
import { Guid } from 'guid-typescript';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TripService {

  //private tripsWebApiUrl = 'https://archexampletrip.azurewebsites.net/api/travels';
  private tripsWebApiUrl = 'https://localhost:44378/api/travels';

  constructor(
    private http: HttpClient) { }

  getTrips(): Observable<Trip[]> {
    return this.http.get<Trip[]>(this.tripsWebApiUrl);
  }

  getTrip(id: Guid): Observable<Trip> {
    return this.http.get<Trip>(this.tripsWebApiUrl+"/"+id)
  }
}
