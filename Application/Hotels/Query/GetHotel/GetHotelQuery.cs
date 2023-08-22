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
        public async Task<Hotel?> Handle(GetHotelQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var hotels = GetHotels();

                var hotel = hotels.Find(x => x.Id == query.Id);

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
