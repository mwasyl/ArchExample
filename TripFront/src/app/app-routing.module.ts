import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TripsComponent } from './trips/trips.component';
import { CustomersComponent } from './customers/customers.component';
import { TripDetailComponent } from './trip-detail/trip-detail.component';


const routes: Routes = [
  { path: 'trips', component: TripsComponent },
  { path: 'customers', component: CustomersComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }