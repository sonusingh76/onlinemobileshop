using MobileOnlineShopSystem.UserMicroservice.Data_Access_Layer.Data;
using MobileOnlineShopSystem.UserMicroservice.Data_Access_Layer.Models;

namespace MobileOnlineShopSystem.UserMicroservice.Data_Access_Layer.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserData _userData;

        public UserRepository(UserData userData)
        {
            _userData = userData;
        }

        public void Add(User user)
        {
            _userData.Users.Add(user);
        }

        public void Update(User user)
        {
            _userData.Users.Update(user);
        }

        public void Delete(User user)
        {
            _userData.Users.Remove(user);
        }

        public User GetById(int id)
        {
            return _userData.Users.Find(id);
        }

        public User GetByUsername(string username)
        {
            return _userData.Users.FirstOrDefault(u => u.Username == username);
        }

        public IEnumerable<User> GetAll()
        {
            return _userData.Users.ToList();
        }

        public bool UsernameExists(string username)
        {
            return _userData.Users.Any(u => u.Username == username);
        }

        public bool EmailExists(string email)
        {
            return _userData.Users.Any(u => u.Email == email);
        }

        public void SaveChanges()
        {
            _userData.SaveChanges();
        }
    }

}
