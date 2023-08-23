using Application.Hotels.Query.GetIds;
using Infrastucture.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Hotels.Query.GetHotel
{
    public class GetHotelQuery : IRequest<Hotel>
    {
        public string Id { get; set; }
    }

    public class GetHotelQueryHandler : IRequestHandler<GetHotelQuery, Hotel>
    {
        public async Task<Hotel> Handle(GetHotelQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var hotels = GetHotels();

                var hotel = hotels.Find(x => x.Id.ToString() == query.Id);

                return hotel; 
            }catch(Exception ex)
            {
                throw;
            }
        }


        public List<Hotel> GetHotels()
        {
            List<Hotel> hotels = new List<Hotel>();

            hotels.Add(new Hotel
            {
                Id = Guid.Parse("1"),
                Name = "Splendid",
                NumberStar = 5,
                RoomNumber = 5,
                Town = new Town
                {
                    Id = Guid.Parse("6"),
                    Name = "Montenegro"
                },
            });

            hotels.Add(new Hotel
            {
                Id = Guid.Parse("2"),
                Name = "Rajski vrt",
                NumberStar = 4,
                RoomNumber = 8,
                Town = new Town
                {
                    Id = Guid.Parse("7"),
                    Name = "Bosnia"
                },
            });

            hotels.Add(new Hotel
            {
                Id = Guid.Parse("3"),    
                Name = "Seraton",
                NumberStar = 5,
                RoomNumber = 8,
                Town = new Town
                {
                    Id = Guid.Parse("8"),
                    Name = "Serbia"
                },
            });

            hotels.Add(new Hotel
            {
                Id = Guid.Parse("4"),
                Name = "Hajat",
                NumberStar = 5,
                RoomNumber = 5,
                Town = new Town
                {
                    Id = Guid.Parse("8"),
                    Name = "Serbia"
                },
            });

            hotels.Add(new Hotel
            {
                Id = Guid.Parse("5"),
                Name = "Interkontinental",
                NumberStar = 5,
                RoomNumber = 7,
                Town = new Town
                {
                    Id = Guid.Parse("8"),
                    Name = "Serbia"
                },
            });

            return hotels;
        }
    }
}
