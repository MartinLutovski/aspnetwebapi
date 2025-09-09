using Avenga.NotesApp.DataAccess.Interfaces;
using Avenga.NotesApp.Domain.Models;

namespace Avenga.NotesApp.Tests.FakeRepositories
{
    public class FakeUserRepository : IUserRepository
    {

        private List<User> _users; // Simulated in-memory data store
        public FakeUserRepository()
        {
            _users = new List<User>()
            {
                new User
                { Id = 1, FirstName = "Bob", LastName = "Bobsky", Username = "Boby_123"

                }
            };
            }
        public void Add(User entity)
        {
            _users.Add(entity);
        }

        public void Delete(User entity)
        {
            _users.Remove(entity);
        }

        public List<User> GetAll()
        {
            return _users;
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        public User GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public User LoginUser(string username, string hashedPassword)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
