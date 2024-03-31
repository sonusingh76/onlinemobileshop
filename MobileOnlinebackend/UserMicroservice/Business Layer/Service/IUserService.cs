using MobileOnlineShopSystem.UserMicroservice.Business_Layer.DTO;

namespace MobileOnlineShopSystem.UserMicroservice.Business_Layer.Service
{
    public interface IUserService
    {
        void RegisterUser(UserDto userDto);
        (string token, int userId) Login(UserLoginDto userLoginDto);
    }

}
