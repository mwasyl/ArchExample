import { Component, OnInit } from '@angular/core';
import { Trip } from '../trip';
import { TripService } from '../trip.service';

@Component({
  selector: 'app-trips',
  templateUrl: './trips.component.html',
  styleUrls: ['./trips.component.css']
})
export class TripsComponent implements OnInit {
  trips: Trip[] = [];
  selectedTrip?: Trip;
  message: string;

  constructor(private tripService: TripService) {}

  getTrips(): void {
    this.tripService.getTrips()
        .subscribe(trips => this.trips = trips);
  }

  onSelect(trip: Trip): void {
    this.selectedTrip = trip;
    this.message = null;
  }

  ngOnInit(): void {
    this.getTrips();
  }

  onSave(): void {

    if (this.validate(this.selectedTrip) === true)
    {
      if (this.selectedTrip.id === null)
      {
        this.tripService.createTrip(this.selectedTrip)
        .subscribe(() => 
        { 
          this.message = "Trip succesfully created."; 
          this.trips.push(this.selectedTrip);
        });
      } else {
        this.tripService.saveTrip(this.selectedTrip)
        .subscribe(() => 
        {
          this.message = "Trip succesfully updated."; 
        });
      }
    }
  }

  onCreateTrip(): void {
    let trip: Trip = {
      id: null,
      destination: null
    };
    this.selectedTrip = trip;
  }

  validate(trip: Trip): boolean {
    if(!trip.destination || 0 === trip.destination.length)
    {
      this.message = "Trip destination is required."; 
      return false;
    } else {
      return true;
    }
  }

}
