﻿using System;
using System.Collections.Generic;
using System.Linq;
using Trip.Core.Aggregates.UserAggregate;
using Trip.Core.Common;
using Trip.Core.Dtos;
using Trip.Core.Exceptions;

namespace Trip.Core.Aggregates.TripAggregate
{
    public class Travel : Entity<TravelId>
    {
        //temporary
        public Travel(TravelId id, string destination)
        {
            Id = id;
            Destination = destination;
            IsCancel = false;
            Customers = new List<Customer>();
        }

        public Travel(TravelId id, string destination, IReadOnlyCollection<Customer> customers)
        {
            Id = id;
            Destination = destination;
            IsCancel = false;
            Customers = customers.ToList();
        }

        public string Destination { get; private set; }
        public List<Customer> Customers { get; private set; }
        public bool IsCancel { get; private set; }

        public void AssignCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new TravelException("Cannot assign Customer. It's null.");
            }
            else if (IsCancel)
            {
                throw new TravelException("Cannot assign Customer. The trip is cancelled.");
            }

            if (Customers == null)
                Customers = new List<Customer>();

            Customers.Add(customer);
        }

        public void Cancel()
        {
            IsCancel = true;
        }

        public TravelDto ToDto()
        {
            return new TravelDto()
            {
                Id = Id.Id,
                Destination = Destination
            };
        }

        public static Travel FromDto(TravelDto travelDto)
        {
            if (travelDto.Id == null)
            {
                travelDto.Id = Guid.NewGuid();
            }
            return new Travel(new TravelId(travelDto.Id.Value), travelDto.Destination);
        }

        public void Edit(Travel editedTravel)
        {
            Destination = editedTravel.Destination;
            Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrEmpty(Destination))
                throw new TravelException("Travel error. Destination is null.");
        }
    }
}
