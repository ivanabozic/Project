using Application.Reservations.Query.GetIds;
using Infrastucture.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reservations.Command.FilterReservation
{
    public class FilterReservationCommand : FilterBase, IRequest<List<Reservation>>
    {
        public string? Id { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Destination { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? Price { get; set; }
    }

    public class FilterReservationCommandHandler : IRequestHandler<FilterReservationCommand, List<Reservation>>
    {
        public async Task<List<Reservation>> Handle(FilterReservationCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var reservations = GetReservations();

    
                if (!string.IsNullOrEmpty(command.Id))
                    reservations = reservations.Where(x => x.Id == command.Id).ToList();
                if (!string.IsNullOrEmpty(command.Name))
                    reservations = reservations.Where(x => x.Name.ToLower().Contains(command.Name.ToLower())).ToList();
                if (!string.IsNullOrEmpty(command.Email))
                    reservations = reservations.Where(x => x.Email.ToLower().Contains(command.Email.ToLower())).ToList();
                if (!string.IsNullOrEmpty(command.Destination))
                    reservations = reservations.Where(x => x.Destination.Id.ToLower().Contains(command.Destination.ToLower())).ToList();
                if (command.Price.HasValue && command.Price > 0)
                    reservations = reservations.Where(x => x.Price == command.Price).ToList();
                if(command.DateFrom.HasValue)
                    reservations = reservations.Where(x => x.DateFrom == command.DateFrom).ToList();
                if (command.DateTo.HasValue)
                    reservations = reservations.Where(x => x.DateTo == command.DateTo).ToList();


                if (command._page.HasValue && command._limit.HasValue)
                    reservations = reservations.Skip((command._page.Value - 1) * command._limit.Value).Take(command._limit.Value).ToList();

                return reservations;

            }
            catch(Exception ex)
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
                Email = "ivana.bozic01@gmail.com",
                Name = "reservation 1",
                Destination = new Country
                {
                    Id = "1",
                    Name = "France"
                },
                DateFrom = DateTime.Parse("2019-06-11 14:40:52"),
                DateTo = DateTime.Parse("2019-06-21 14:40:52"),
                Price = 104000
            });

            reservations.Add(new Reservation
            {
                Id = "2",
                Name= "reservation 2",
                Email = "marko.markovic01@gmail.com",
                Destination = new Country
                {
                    Id = "5",
                    Name = "Portugal"
                },
                DateFrom = DateTime.Parse("2020-03-11 14:40:52"),
                DateTo = DateTime.Parse("2020-03-21 14:40:52"),
                Price = 64000
            });

            reservations.Add(new Reservation
            {
                Id = "3",
                Email = "petar.petrovic@gmail.com",
                Name= "reservation 3",
                Destination = new Country
                {
                    Id = "3",
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
                    Id = "3",
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
                    Id = "3",
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
