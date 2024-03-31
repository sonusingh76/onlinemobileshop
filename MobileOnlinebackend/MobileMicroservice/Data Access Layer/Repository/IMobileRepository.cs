using MobileOnlineShopSystem.MobileMicroservice.Data_Access_Layer.Models;

namespace MobileOnlineShopSystem.MobileMicroservice.Data_Access_Layer.Repository
{
    public interface IMobileRepository
    {
        IEnumerable<Mobile> GetAllMobiles();
        Mobile GetMobileById(int id);
        void AddMobile(Mobile mobile);
        void UpdateMobile(int id, Mobile mobile);
        void DeleteMobile(int id);
    }
}

