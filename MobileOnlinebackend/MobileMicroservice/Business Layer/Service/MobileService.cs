using MobileOnlineShopSystem.MobileMicroservice.Business_Layer.DTO;
using MobileOnlineShopSystem.MobileMicroservice.Data_Access_Layer.Models;
using MobileOnlineShopSystem.MobileMicroservice.Data_Access_Layer.Repository;

namespace MobileOnlineShopSystem.MobileMicroservice.Business_Layer.Service
{
    public class MobileService : IMobileService
    {
        private readonly IMobileRepository _mobileRepository;

        public MobileService(IMobileRepository mobileRepository)
        {
            _mobileRepository = mobileRepository;
        }

        public IEnumerable<MobileDto> GetAllMobiles()
        {
            var mobileEntities = _mobileRepository.GetAllMobiles();
            var mobileDtos = new List<MobileDto>();

            foreach (var mobileEntity in mobileEntities)
            {
                var mobileDto = MapToDto(mobileEntity);
                mobileDtos.Add(mobileDto);
            }

            return mobileDtos;
        }

        public MobileDto GetMobileById(int id)
        {
            var mobileEntity = _mobileRepository.GetMobileById(id);
            if (mobileEntity == null)
            {
                throw new Exception("Mobile not found.");
            }

            var mobileDto = MapToDto(mobileEntity);
            return mobileDto;
        }

        public void AddMobile(MobileDto mobileDto)
        {
            if (mobileDto == null)
            {
                throw new ArgumentNullException(nameof(mobileDto));
            }

            if (string.IsNullOrWhiteSpace(mobileDto.Brand))
            {
                throw new Exception("Brand is required.");
            }

            if (string.IsNullOrWhiteSpace(mobileDto.Model))
            {
                throw new Exception("Model is required.");
            }

            // Map the DTO to the entity
            var mobileEntity = MapToEntity(mobileDto);

            // Add the mobile to the repository
            _mobileRepository.AddMobile(mobileEntity);
        }

        public void UpdateMobile(int id, MobileDto mobileDto)
        {
            if (mobileDto == null)
            {
                throw new ArgumentNullException(nameof(mobileDto));
            }

           
            if (string.IsNullOrWhiteSpace(mobileDto.Brand))
            {
                throw new Exception("Brand is required.");
            }

            if (string.IsNullOrWhiteSpace(mobileDto.Model))
            {
                throw new Exception("Model is required.");
            }

            var existingMobile = _mobileRepository.GetMobileById(id);
            if (existingMobile == null)
            {
                throw new Exception("Mobile not found.");
            }

            // Map the DTO to the entity
            var mobileEntity = MapToEntity(mobileDto);


            // Update the mobile in the repository
            _mobileRepository.UpdateMobile(id, mobileEntity);
        }

        public void DeleteMobile(int id)
        {
            var existingMobile = _mobileRepository.GetMobileById(id);
            if (existingMobile == null)
            {
                throw new Exception("Mobile not found.");
            }

           

            // Delete the mobile from the repository
            _mobileRepository.DeleteMobile(id);
        }

        private MobileDto MapToDto(Mobile mobileEntity)
        {
            return new MobileDto
            {
                Id = mobileEntity.Id,
                Brand = mobileEntity.Brand,
                Model = mobileEntity.Model,
                Price = mobileEntity.Price,
                Description = mobileEntity.Description,
                ImageUrl = mobileEntity.ImageUrl
            };
        }

        private Mobile MapToEntity(MobileDto mobileDto)
        {
            return new Mobile
            {
                Id = mobileDto.Id,
                Brand = mobileDto.Brand,
                Model = mobileDto.Model,
                Price = mobileDto.Price,
                Description = mobileDto.Description,
                ImageUrl = mobileDto.ImageUrl
            };
        }
    }
}
