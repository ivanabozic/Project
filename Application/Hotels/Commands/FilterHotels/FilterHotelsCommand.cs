using Application.Destinations.Query.GetCountries;
using Infrastucture.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Hotels.Commands.FilterHotels
{
    public class FilterHotelsCommand : FilterBase, IRequest<List<Hotel>>
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public int? NumberStar { get; set; }
        public string? Destination { get; set; }
        public int? RoomNumber { get; set; }
    }

    public class FilterHotelsCommandHandler : IRequestHandler<FilterHotelsCommand, List<Hotel>>
    {
        public async Task<List<Hotel>> Handle(FilterHotelsCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var hotels = GetHotels();


                if (!string.IsNullOrEmpty(command.Id))
                    hotels = hotels.Where(x => x.Id == command.Id).ToList();
                if (!string.IsNullOrEmpty(command.Name))
                    hotels = hotels.Where(x => x.Name.ToLower().Contains(command.Name.ToLower())).ToList();
                if (!string.IsNullOrEmpty(command.Destination))
                    hotels = hotels.Where(x => x.Destination.Name.ToLower().Contains(command.Destination.ToLower())).ToList();
                if (command.RoomNumber.HasValue && command.RoomNumber > 0)
                    hotels = hotels.Where(x => x.RoomNumber == command.RoomNumber).ToList();
                if (command.NumberStar.HasValue && command.NumberStar > 0) 
                    hotels = hotels.Where(x => x.NumberStar == command.NumberStar).ToList();


                if (command._page.HasValue && command._limit.HasValue)
                    hotels = hotels.Skip((command._page.Value - 1) * command._limit.Value).Take(command._limit.Value).ToList();

                return hotels;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public List<Hotel> GetHotels()
        {
            List<Hotel> hotels = new List<Hotel>();

            hotels.Add(new Hotel
            {
                Id = "1",
                Name = "Splendid",
                NumberStar = 5,
                RoomNumber = 5,
                Destination = new Country
                {
                    Id = "6",
                    Name = "Montenegro"
                },
            });

            hotels.Add(new Hotel
            {
                Id = "2",
                Name = "Rajski vrt",
                NumberStar = 4,
                RoomNumber = 8,
                Destination = new Country
                {
                    Id = "7",
                    Name = "Bosnia"
                },
            });

            hotels.Add(new Hotel
            {
                Id = "3",
                Name = "Seraton",
                NumberStar = 5,
                RoomNumber = 8,
                Destination = new Country
                {
                    Id = "8",
                    Name = "Serbia"
                },
            });

            hotels.Add(new Hotel
            {
                Id = "4",
                Name = "Hajat",
                NumberStar = 5,
                RoomNumber = 5,
                Destination = new Country
                {
                    Id = "8",
                    Name = "Serbia"
                },
            });

            hotels.Add(new Hotel
            {
                Id = "5",
                Name = "Interkontinental",
                NumberStar = 5,
                RoomNumber = 7,
                Destination = new Country
                {
                    Id = "8",
                    Name = "Serbia"
                },
            });

            return hotels;
        }
    }

}
