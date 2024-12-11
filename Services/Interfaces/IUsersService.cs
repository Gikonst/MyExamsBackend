using MyExamsBackend.Models;

namespace MyExamsBackend.Services.Interfaces
{
    public interface IUsersService
    {
        public List<User> GetAll();
        public User GetById(int id);
        public bool Create(User user);
        public bool Update(User user);
        public bool Delete(int id);
    }
}
