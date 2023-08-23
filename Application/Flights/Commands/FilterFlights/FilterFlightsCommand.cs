using Application.Destinations.Command.FilterDestinations;
using Infrastucture.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Flights.Commands.FilterFlights
{
    public class FilterFlightsCommand : FilterBase, IRequest<List<Flight>>
    {
        public string? Id { get; set; }
        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public int? Price { get; set; }
    }

    public class GetFlightsQueryHandler : IRequestHandler<FilterFlightsCommand, List<Flight>>
    {

        public async Task<List<Flight>> Handle(FilterFlightsCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var flights = GetFlights();

                if (!string.IsNullOrEmpty(command.Id))
                    flights = flights.Where(x => x.Id == command.Id).ToList();
                if (!string.IsNullOrEmpty(command.Origin))
                    flights = flights.Where(x => x.Origin.Name.ToLower().Contains(command.Origin.ToLower())).ToList();
                if (!string.IsNullOrEmpty(command.Destination))
                    flights = flights.Where(x => x.Destination.Name.ToLower().Contains(command.Destination.ToLower())).ToList();
                if (command.Price != null)
                    flights = flights.Where(x => x.Price == command.Price).ToList();


                if (command._page.HasValue && command._limit.HasValue)
                    flights = flights.Skip((command._page.Value - 1) * command._limit.Value).Take(command._limit.Value).ToList();

                return flights;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private List<Flight> GetFlights()
        {
            List<Flight> flights = new List<Flight>();

            flights.Add(
                new Flight
                {
                    Id = "1",
                    Origin = new Country
                    {
                        Id = Guid.Parse("1"),
                        Name = "France"
                    },
                    Destination = new Country
                    {
                        Id = Guid.Parse("3"),
                        Name = "Turkey"
                    },
                    Departure = DateTime.Parse("2019-05-08 14:40:52"),
                    Return = DateTime.Parse("2019-05-08 19:40:52"),
                    Price = 25000

                });

            flights.Add(
                new Flight
                {
                    Id = "2",
                    Origin = new Country
                    {
                        Id = Guid.Parse("3"),
                        Name = "Turkey"
                    },
                    Destination = new Country
                    {
                        Id = Guid.Parse("5"),
                        Name = "Portugal"
                    },
                    Departure = DateTime.Parse("2019-05-10 11:40:52"),
                    Return = DateTime.Parse("2019-05-10 12:40:52"),
                    Price = 25800

                });

            flights.Add(
                new Flight
                {
                    Id = "3",
                    Origin = new Country
                    {
                        Id = Guid.Parse("1"),
                        Name = "France"
                    },
                    Destination = new Country
                    {
                        Id = Guid.Parse("5"),
                        Name = "Portugal"
                    },
                    Departure = DateTime.Parse("2019-05-15 11:40:52"),
                    Return = DateTime.Parse("2019-05-15 12:40:52"),
                    Price = 19000

                });

            flights.Add(
                new Flight
                {
                    Id = "4",
                    Origin = new Country
                    {
                        Id = Guid.Parse("5"),
                        Name = "Portugal"
                    },
                    Destination = new Country
                    {
                        Id = Guid.Parse("1"),
                        Name = "France"
                    },
                    Departure = DateTime.Parse("2019-05-12 11:40:52"),
                    Return = DateTime.Parse("2019-05-12 12:40:52"),
                    Price = 19000

                });

            return flights;
        }
    }


}
