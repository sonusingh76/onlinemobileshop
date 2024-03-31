using MobileOnlineShopSystem.MobileMicroservice.Business_Layer.DTO;

namespace MobileOnlineShopSystem.MobileMicroservice.Business_Layer.Service
{
    public interface IMobileService
    {
        IEnumerable<MobileDto> GetAllMobiles();
        MobileDto GetMobileById(int id);
        void AddMobile(MobileDto mobileDto);
        void UpdateMobile(int id, MobileDto mobileDto);
        void DeleteMobile(int id);
    }
}
