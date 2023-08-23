using Application.Users.Commands.FilterUsers;
using Infrastucture.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Destinations.Command.FilterDestinations
{
    public class FilterDestinationsCommand : FilterBase, IRequest<List<Destination>>
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Country { get; set; }
    }

    public class FilterDestinationsCommandHandler : IRequestHandler<FilterDestinationsCommand, List<Destination>>
    {
        public async Task<List<Destination>> Handle(FilterDestinationsCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var destinations = GetDestinations();

                var filterDestinations = new List<Destination>();
                filterDestinations = destinations;

                if (!string.IsNullOrEmpty(command.Id))
                    destinations = destinations.Where(x => x.Id == command.Id).ToList();
                if (!string.IsNullOrEmpty(command.Name))
                    destinations = destinations.Where(x => x.Name.ToLower().Contains(command.Name.ToLower())).ToList();
                if (!string.IsNullOrEmpty(command.Description))
                    destinations = destinations.Where(x => x.Description.ToLower().Contains(command.Description.ToLower())).ToList();
                if (!string.IsNullOrEmpty(command.Country))
                    destinations = destinations.Where(x => x.Country.Name.ToLower().Contains(command.Country.ToLower())).ToList();


                if (command._page.HasValue && command._limit.HasValue)
                    destinations = destinations.Skip((command._page.Value - 1) * command._limit.Value).Take(command._limit.Value).ToList();

                return destinations;
            }
            catch (Exception e) 
            {
                throw;
            }
        }

        private List<Destination> GetDestinations()
        {
            List<Destination> destinations = new List<Destination>();

            destinations.Add(
                new Destination
                {
                    Id = "1",
                    Name = "Paris",
                    Description = "Paris (English: /ˈpærɪs/; French pronunciation: ​[paʁi] (listen)) is the capital and most populous city of France, with an official estimated population of 2,102,650 residents as of 1 January 2023[2] in an area of more than 105 km2 (41 sq mi),[5] making it the fourth-most populated city in the European Union as well as the 30th most densely populated city in the world in 2022.",
                    Country = new Country
                    {
                        Id = Guid.Parse("1"),
                        Name = "France"
                    }
                });


            destinations.Add(new Destination
            {
                Id = "2",
                Name = "Barcelona",
                Description = "Barcelona is a city on the northeastern coast of Spain. It is the capital and largest city of the autonomous community of Catalonia, as well as the second most populous municipality of Spain. ",
                Country = new Country {
                    Id = Guid.Parse("2"),
                    Name = "Spain"
                }
            });

            destinations.Add(new Destination
            {
                Id = "3",
                Name = "Valensia",
                Description = "Valencia is the capital of the autonomous community of Valencia and the third-most populated municipality in Spain, with 792,492 inhabitants (2022). It is the capital of the province of the same name.",
                Country = new Country
                {
                    Id = Guid.Parse("2"),
                    Name = "Spain"
                }

            });

            destinations.Add(new Destination
            {
                Id = "4",
                Name = "Istanbul",
                Description = "Istanbul (/ˌɪstænˈbʊl/ IST-an-BUUL,[7][8] US also /ˈɪstænbʊl/ IST-an-buul; Turkish: İstanbul [isˈtanbuɫ] (listen)), formerly known as Constantinople from 330 AD until 1930 AD[b] (Greek: Κωνσταντινούπολις; Latin: Constantinopolis; Ottoman Turkish: قسطنطينيه), is the largest city in Turkey, serving as the country's economic, cultural and historic hub. ",
                Country= new Country
                {
                    Id = Guid.Parse("3"),
                    Name="Turkey"
                }
            });

            return destinations;
        }
    }
}
