using MobileOnlineShopSystem.UserMicroservice.Data_Access_Layer.Models;

namespace MobileOnlineShopSystem.UserMicroservice.Data_Access_Layer.Repository
{
    public interface IUserRepository
    {
        void Add(User user);
        void Update(User user);
        void Delete(User user);
        User GetById(int id);
        User GetByUsername(string username);
        IEnumerable<User> GetAll();
        bool UsernameExists(string username);
        bool EmailExists(string email);
        void SaveChanges();
    }

}
