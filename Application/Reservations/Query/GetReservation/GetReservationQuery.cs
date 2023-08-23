using Application.Reservations.Query.GetIds;
using Infrastucture.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reservations.Query.GetReservation
{
    public class GetReservationQuery : IRequest<Reservation>
    {
        public string Id { get; set; }

    }


    public class GetReservationQueryHandler : IRequestHandler<GetReservationQuery, Reservation>
    {
        public async Task<Reservation?> Handle(GetReservationQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var reservations = GetReservations();

                var reservation = reservations.Find(x => x.Id == query.Id);

                return reservation;
            }catch(Exception ex)
            {
                throw;
            }
        }

        public List<Reservation> GetReservations()
        {
            List<Reservation> reservations = new List<Reservation>();

            reservations.Add(new Reservation
            {
                Id = "1",
                Name ="reservation 1",
                Email = "ivana.bozic01@gmail.com",
                Destination = new Country
                {
                    Id = Guid.Parse("1"),
                    Name = "France"
                },
                DateFrom = DateTime.Parse("2019-06-11 14:40:52"),
                DateTo = DateTime.Parse("2019-06-21 14:40:52"),
                Price = 104000
            });

            reservations.Add(new Reservation
            {
                Id = "2",
                Name = "reservation 2",
                Email = "marko.markovic01@gmail.com",
                Destination = new Country
                {
                    Id = Guid.Parse("5"),
                    Name = "Portugal"
                },
                DateFrom = DateTime.Parse("2020-03-11 14:40:52"),
                DateTo = DateTime.Parse("2020-03-21 14:40:52"),
                Price = 64000
            });

            reservations.Add(new Reservation
            {
                Id = "3",
                Name = "reservation 3",
                Email = "petar.petrovic@gmail.com",
                Destination = new Country
                {
                    Id = Guid.Parse("3"),
                    Name = "Turkey"
                },
                DateFrom = DateTime.Parse("2020-04-11 14:40:52"),
                DateTo = DateTime.Parse("2020-04-21 14:40:52"),
                Price = 87000
            });


            reservations.Add(new Reservation
            {
                Id = "4",
                Email = "petar.petrovic@gmail.com",
                Name = "reservation 4",
                Destination = new Country
                {
                    Id = Guid.Parse("3"),
                    Name = "Turkey"
                },
                DateFrom = DateTime.Parse("2020-04-11 14:40:52"),
                DateTo = DateTime.Parse("2020-04-21 14:40:52"),
                Price = 87000
            });

            reservations.Add(new Reservation
            {
                Id = "5",
                Email = "petar.petrovic@gmail.com",
                Name = "reservation 5",
                Destination = new Country
                {
                    Id = Guid.Parse("3"),
                    Name = "Turkey"
                },
                DateFrom = DateTime.Parse("2020-04-11 14:40:52"),
                DateTo = DateTime.Parse("2020-04-21 14:40:52"),
                Price = 87000
            });

            return reservations;
        }

    }
}
