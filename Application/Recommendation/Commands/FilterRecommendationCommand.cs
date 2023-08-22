using Application.Destinations.Command.FilterDestinations;
using Infrastucture.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Recommendation.Commands
{
    public class FilterRecommendationCommand : FilterBase, IRequest<List<Infrastucture.Models.Recommendation>>
    {
        public string? Id { get; set; }
        public string? Destination { get; set; }
        public float? Price { get; set; }
        
    }

    public class FilterRecommendationCommandHandler : IRequestHandler<FilterRecommendationCommand, List<Infrastucture.Models.Recommendation>>
    {
        public async Task<List<Infrastucture.Models.Recommendation>> Handle(FilterRecommendationCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var recommendations = GetRecommendations();

                if (!string.IsNullOrEmpty(command.Id))
                    recommendations = recommendations.Where(x => x.Id == command.Id).ToList();
                if (!string.IsNullOrEmpty(command.Destination))
                    recommendations = recommendations.Where(x => x.Destination.Name.ToLower().Contains(command.Destination.ToLower())).ToList();
                if (command.Price != null)
                    recommendations = recommendations.Where(x => x.Price == command.Price).ToList();

                if (command._page.HasValue && command._limit.HasValue)
                    recommendations = recommendations.Skip((command._page.Value - 1) * command._limit.Value).Take(command._limit.Value).ToList();

                return recommendations;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private List<Infrastucture.Models.Recommendation> GetRecommendations()
        {
            List<Infrastucture.Models.Recommendation> recommendations = new List<Infrastucture.Models.Recommendation>();

            recommendations.Add(
                new Infrastucture.Models.Recommendation
                {
                    Id = "1",
                    Destination = new Country
                    {
                        Id = "5",
                        Name = "Portugal"
                    },
                    Price = 35000,
                    Departure = DateTime.Parse("2019-06-11 14:40:52")

                });

            recommendations.Add(
                new Infrastucture.Models.Recommendation
                {
                    Id = "2",
                    Destination = new Country
                    {
                        Id = "3",
                        Name = "Turkey"
                    },
                    Price = 55000,
                    Departure = DateTime.Parse("2019-06-15 14:40:52")

                });

            recommendations.Add(
                new Infrastucture.Models.Recommendation
                {
                    Id = "3",
                    Destination = new Country
                    {
                        Id = "2",
                        Name = "Spain"
                    },
                    Price = 65000,
                    Departure = DateTime.Parse("2019-06-09 14:40:52")

                });


            return recommendations;
        }
    }


}
