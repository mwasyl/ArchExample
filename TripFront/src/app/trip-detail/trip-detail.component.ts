import { Component, OnInit } from '@angular/core';
import { Trip } from '../trip';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { TripService } from '../trip.service';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-trip-detail',
  templateUrl: './trip-detail.component.html',
  styleUrls: ['./trip-detail.component.css']
})
export class TripDetailComponent implements OnInit {

  trip: Trip;

  constructor(
    private route: ActivatedRoute,
    private tripService: TripService,
    private location: Location
  ) {}

  ngOnInit(): void {
    this.getTrip();
  }

  getTrip(): void {
    const id = this.route.snapshot.paramMap.get('id');
    const guid = Guid.parse(id);

    this.tripService.getTrip(guid)
      .subscribe(trip => this.trip = trip);
  }

  goBack(): void {
    this.location.back();
  }

}
