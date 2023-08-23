using Infrastucture.Models;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Query
{
    public class GetUsersQuery : FilterBase, IRequest<List<User>>
    {
    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<User>>
    {
        public async Task<List<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var users = GetUsers();

                if (request._page.HasValue && request._limit.HasValue)
                    users = users.Skip((request._page.Value - 1) * request._limit.Value).Take(request._limit.Value).ToList();


                return users;

            }catch(Exception e)
            {
                throw;
            }
        }

        private List<User> GetUsers()
        {
            List<User> users = new List<User>();

            users.Add(
                new User
                {
                    Id = Guid.Parse("1"),
                    Name = "Petar",
                    Lastname = "Petrovic",
                    Username = "petar001",
                    Email = "petar.petrovic@gmail.com"
                });


            users.Add(new User
            {
                Id = Guid.Parse("2"),
                Name = "Marko",
                Lastname = "Markovic",
                Username = "marko001",
                Email = "marko.markovic@gmail.com"
            });

            users.Add(new User
            {
                Id = Guid.Parse("3"),
                Name = "Ana",
                Lastname = "Anic",
                Username = "ana001",
                Email = "ana.anaic@gmail.com"
            });

            users.Add(new User
            {
                Id = Guid.Parse("4"),
                Name = "Nikolina",
                Lastname = "Nikolic",
                Username = "nikolina001",
                Email = "nikolina.nikolic@gmail.com"
            });

            users.Add(new User
            {
                Id = Guid.Parse("5"),
                Name = "Nemanja",
                Lastname = "Maric",
                Username = "nemanja001",
                Email = "nemanja.maric01@gmail.com"
            });

            return users ;
        }

    }
}
