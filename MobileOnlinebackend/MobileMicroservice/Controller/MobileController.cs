using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobileOnlineShopSystem.MobileMicroservice.Business_Layer.DTO;
using MobileOnlineShopSystem.MobileMicroservice.Business_Layer.Service;
using System.Data;

namespace MobileOnlineShopSystem.MobileMicroservice.Controller
{
    [Route("api/mobiles")]
    [ApiController]
    public class MobileController : ControllerBase
    {
        private readonly IMobileService _mobileService;

        public MobileController(IMobileService mobileService)
        {
            _mobileService = mobileService;
        }

        [HttpGet]
       // [Authorize(Roles = "Admin")]
        public IEnumerable<MobileDto> GetAllMobiles()
        {
            return _mobileService.GetAllMobiles();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<MobileDto> GetMobileById(int id)
        {
            try
            {
                var mobileDto = _mobileService.GetMobileById(id);
                return mobileDto;
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")] 
        public ActionResult AddMobile([FromBody] MobileDto mobileDto)
        {
            try
            {
                _mobileService.AddMobile(mobileDto);
                return Ok("Mobile Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")] 
        public ActionResult UpdateMobile(int id, [FromBody] MobileDto mobileDto)
        {
            try
            {
                _mobileService.UpdateMobile(id, mobileDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")] 
        public ActionResult DeleteMobile(int id)
        {
            try
            {
                _mobileService.DeleteMobile(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}