using Application.Reservations.Query.GetIds;
using Infrastucture.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Hotels.Query.GetIds
{
    public class GetHotelIdsQuery : IRequest<List<SelectIdName>>
    {
    }

    public class GetHotelIdsQueryHandler : IRequestHandler<GetHotelIdsQuery, List<SelectIdName>>
    {
        public async Task<List<SelectIdName>> Handle(GetHotelIdsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var hotels = GetHotels();

                return hotels;
            }catch(Exception ex)
            {
                throw;
            }
        }


        public List<SelectIdName> GetHotels()
        {
            List<SelectIdName> hotels = new List<SelectIdName>();

            hotels.Add(new SelectIdName
            {
                Id = "1",
                Name = "Splendid"
            });

            hotels.Add(new SelectIdName
            {
                Id = "2",
                Name = "Rajski vrt"
            });

            hotels.Add(new SelectIdName
            {
                Id = "3",
                Name = "Seraton"
            });
            hotels.Add(new SelectIdName
            {
                Id = "4",
                Name = "Hajat"
            });
            hotels.Add(new SelectIdName
            {
                Id = "5",
                Name = "Interkontinental"
            });

            return hotels;
        }
    }
}
