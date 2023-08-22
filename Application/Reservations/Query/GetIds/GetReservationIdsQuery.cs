using Application.Flights.Commands.FilterFlights;
using Infrastucture.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reservations.Query.GetIds
{
    public class GetReservationIdsQuery : IRequest<List<SelectIdName>>
    {
    }

    public class GetReservationIdsQueryHandler : IRequestHandler<GetReservationIdsQuery, List<SelectIdName>>
    {
        public async Task<List<SelectIdName>> Handle(GetReservationIdsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return GetReservations();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<SelectIdName> GetReservations()
        {
            List<SelectIdName> reservations = new List<SelectIdName>();

            reservations.Add(new SelectIdName
             {
                Id = "1",
                Name = "reservation 1"
            });

            reservations.Add(new SelectIdName
            {
                Id = "2",
                Name = "reservation 2"
            });

            reservations.Add(new SelectIdName
            {
                Id = "3",
                Name = "reservation 3"
            });
            reservations.Add(new SelectIdName
            {
                Id = "4",
                Name = "reservation 4"
            });
            reservations.Add(new SelectIdName
            {
                Id = "5",
                Name = "reservation 5"
            });

            return reservations;
        }

    }
}
