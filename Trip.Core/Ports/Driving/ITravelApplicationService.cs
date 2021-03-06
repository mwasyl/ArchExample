using System;
using Trip.Core.Dtos;

namespace Trip.Core.Ports.Driving
{
    public interface ITravelApplicationService
    {
        void CreateTravel(TravelDto travelDto);
        void EditTravel(TravelDto travelDto);
        void AssignCustomerToTravel(Guid travelId, Guid customerId);
    }
}
