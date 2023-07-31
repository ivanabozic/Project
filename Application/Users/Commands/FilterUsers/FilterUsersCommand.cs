using Infrastucture.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.FilterUsers
{
    public class FilterUsersCommand : FilterBase, IRequest<List<User>>
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }

    }

    public class FilterUsersCommandHandler : IRequestHandler<FilterUsersCommand, List<User>>
    {
        public async Task<List<User>> Handle(FilterUsersCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var users = GetUsers();

                var filterUsers = new List<User>();
                filterUsers = users;

                if(!string.IsNullOrEmpty(command.Id))
                    users = users.Where(x => x.Id == command.Id).ToList();
                if (!string.IsNullOrEmpty(command.Name))
                    users = users.Where(x => x.Name.ToLower().Contains(command.Name.ToLower())).ToList();
                if(!string.IsNullOrEmpty(command.Username))
                    users = users.Where(x => x.Username.ToLower().Contains(command.Username.ToLower())).ToList();
                if (!string.IsNullOrEmpty(command.Email))
                    users = users.Where(x => x.Email.ToLower().Contains(command.Email.ToLower())).ToList();


                if (command._page.HasValue && command._limit.HasValue)
                    users = users.Skip((command._page.Value - 1) * command._limit.Value).Take(command._limit.Value).ToList();

                return users;
            }
            catch (Exception e)
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
                    Id = "1",
                    Name = "Petar",
                    Lastname = "Petrovic",
                    Username = "petar001",
                    Email = "petar.petrovic@gmail.com"
                });


            users.Add(new User
            {
                Id = "2",
                Name = "Marko",
                Lastname = "Markovic",
                Username = "marko001",
                Email = "marko.markovic@gmail.com"
            });

            users.Add(new User
            {
                Id = "3",
                Name = "Ana",
                Lastname = "Anic",
                Username = "ana001",
                Email = "ana.anaic@gmail.com"
            });

            users.Add(new User
            {
                Id = "4",
                Name = "Nikolina",
                Lastname = "Nikolic",
                Username = "nikolina001",
                Email = "nikolina.nikolic@gmail.com"
            });

            users.Add(new User
            {
                Id = "5",
                Name = "Nemanja",
                Lastname = "Maric",
                Username = "nemanja001",
                Email = "nemanja.maric01@gmail.com"
            });

            return users;
        }
    }


}
