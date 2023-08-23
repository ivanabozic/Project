using Application.Users.Commands.FilterUsers;
using Infrastucture.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Destinations.Query.GetCountries
{
    public class GetCountriesQuery : IRequest<List<Country>>
    {
    }

    public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, List<Country>>
    {
        public async Task<List<Country>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var countries = GetCountries();

                return countries;
            }
            catch(Exception e) 
            {
                throw;
            }
        }

        private List<Country> GetCountries()
        {
            List<Country> countries = new List<Country>();

            countries.Add(
                new Country
                {
                    Id = Guid.Parse("1"),
                    Name = "France"
                });


            countries.Add(new Country
            {
                Id = Guid.Parse("2"),
                Name = "Spain",
            });

            countries.Add(new Country
            {
                Id = Guid.Parse("3"),
                Name = "Turkey",

            });

            countries.Add(new Country
            {
                Id = Guid.Parse("4"),
                Name = "Germany",
            });

            countries.Add(new Country
            {
                Id = Guid.Parse("5"),
                Name = "Portugal",
            });

            countries.Add(new Country
            {
                Id = Guid.Parse("6"),
                Name = "Montenegro",
            });
            countries.Add(new Country
            {
                Id = Guid.Parse("7"),
                Name = "Bosia",
            });
            countries.Add(new Country
            {
                Id = Guid.Parse("8"),
                Name = "Serbia",
            });

            return countries;
        }

    }
}
