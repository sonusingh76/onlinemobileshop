using MobileOnlineShopSystem.MobileMicroservice.Data_Access_Layer.Models;
using MobileOnlineShopSystem.UserMicroservice.Data_Access_Layer.Data;

namespace MobileOnlineShopSystem.MobileMicroservice.Data_Access_Layer.Repository
{
    public class MobileRepository : IMobileRepository
    {
        private readonly UserData _dbContext;

        public MobileRepository(UserData dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Mobile> GetAllMobiles()
        {
            return _dbContext.Mobiles.ToList();
        }

        public Mobile GetMobileById(int id)
        {
            return _dbContext.Mobiles.FirstOrDefault(m => m.Id == id);
        }

        public void AddMobile(Mobile mobile)
        {
            _dbContext.Mobiles.Add(mobile);
            _dbContext.SaveChanges();
        }

        public void UpdateMobile(int id, Mobile mobile)
        {
            var existingMobile = _dbContext.Mobiles.Find(id);
            if (existingMobile != null)
            {
                existingMobile.Brand = mobile.Brand;
                existingMobile.Model = mobile.Model;
                existingMobile.Price = mobile.Price;
                existingMobile.Description = mobile.Description;
                existingMobile.ImageUrl = mobile.ImageUrl;

                _dbContext.Mobiles.Update(existingMobile);
                _dbContext.SaveChanges();
            }
        }
        public void DeleteMobile(int id)
        {
            var mobile = _dbContext.Mobiles.FirstOrDefault(m => m.Id == id);
            if (mobile != null)
            {
                _dbContext.Mobiles.Remove(mobile);
                _dbContext.SaveChanges();
            }
        }

       
    }
}