import { Injectable } from '@angular/core';
import { Trip } from './trip';
import { Observable, of } from 'rxjs';
import { Guid } from 'guid-typescript';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class TripService {

  //This setting should be in config:
  //private tripsWebApiUrl = 'https://archexampletrip.azurewebsites.net/api/travels';
  private tripsWebApiUrl = 'https://localhost:44378/api/travels';
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private http: HttpClient) { }

  getTrips(): Observable<Trip[]> {
    return this.http.get<Trip[]>(this.tripsWebApiUrl);
  }

  getTrip(id: Guid): Observable<Trip> {
    return this.http.get<Trip>(this.tripsWebApiUrl+"/"+id)
  }

  saveTrip(trip: Trip): Observable<any> {
    return this.http.patch(this.tripsWebApiUrl, trip, this.httpOptions)
    .pipe(
        tap(_ => console.log(`updated trip id=${trip.id}`)),
        catchError(this.handleError<any>('updatetrip'))
      );
  }

  createTrip(trip: Trip): Observable<any> {
    return this.http.post(this.tripsWebApiUrl, trip, this.httpOptions)
    .pipe(
        tap(_ => console.log(`created trip id=${trip.id}`)),
        catchError(this.handleError<any>('createtrip'))
      );
  }  

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
  
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }  
}
