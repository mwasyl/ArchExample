import { Injectable } from '@angular/core';
import { Customer } from './customer';
import { Observable, of } from 'rxjs';
import { Guid } from 'guid-typescript';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  //https://localhost:44378/
  //private customersWebApiUrl = 'https://archexampletrip.azurewebsites.net/api/customers';
  private customersWebApiUrl = 'https://localhost:44378/api/customers';

  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private http: HttpClient) { }

  getCustomers(): Observable<Customer[]> {
    return this.http.get<Customer[]>(this.customersWebApiUrl);
  }

  getCustomer(id: Guid): Observable<Customer> {
    return this.http.get<Customer>(this.customersWebApiUrl+"/"+id)
  }

  saveCustomer(customer: Customer): Observable<any> {
    return this.http.patch(this.customersWebApiUrl, customer, this.httpOptions)
    .pipe(
        tap(_ => console.log(`updated customer id=${customer.id}`)),
        catchError(this.handleError<any>('updateCustomer'))
      );
  }

  createCustomer(customer: Customer): Observable<any> {
    return this.http.post(this.customersWebApiUrl, customer, this.httpOptions)
    .pipe(
        tap(_ => console.log(`created customer id=${customer.id}`)),
        catchError(this.handleError<any>('createCustomer'))
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
