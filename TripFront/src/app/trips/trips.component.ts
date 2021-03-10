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

  constructor(private tripService: TripService) {}

  getTrips(): void {
    this.tripService.getTrips()
        .subscribe(trips => this.trips = trips);
  }

  ngOnInit(): void {
    this.getTrips();
  }

}
