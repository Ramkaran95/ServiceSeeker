using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceSeeker.Data;
using ServiceSeeker.Model;
using ServiceSeeker.Model.ProviderDTO;
using static System.Net.WebRequestMethods;


namespace ServiceSeeker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly ServiceSeekerDB _dbContext;          
        public ProviderController(ServiceSeekerDB _dbContext)
        {
            this._dbContext = _dbContext;
        }

        [HttpGet]
        public ActionResult GetUser()

        {
            var allUser = _dbContext.Providers.ToList();
            return Ok(allUser);
        }

        [HttpPost]
        [Route("Registation")]
        public ActionResult UserReg(RegDTO providersDTO)
        {
            if (providersDTO == null)
            {

                return BadRequest("Invalid data..!");


            }
            //ModelState.IsValid return false value when user send invalid data.
            //It ensure the data integrity of incoming requests in Web APIs.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //FirstOrDefault Retrieves the first user that matches a condition or returns null if no match is found.
            var existingUser = _dbContext.Providers.FirstOrDefault(x => x.Email == providersDTO.Email || x.UserName == providersDTO.UserName);
            if (existingUser != null)
            {

                return BadRequest("User already exists with same email address");

            }

            var data = new Provider()
            {
                ProviderId = providersDTO.ProviderId,
                CreateAt = DateTime.Now,
                UserName = providersDTO.UserName,
                Email = providersDTO.Email,
                FirstName = providersDTO.FirstName,
                LastName = providersDTO.LastName,
                MiddleName = providersDTO.MiddleName,
                Password = providersDTO.Password,
                PhoneNumber = providersDTO.PhoneNumber,
                ProfilePhoto = providersDTO.ProfilePhoto,
                ProfessionType=providersDTO.ProfessionType,
                YearOfEx = providersDTO.YearOfEx,
                Bio =providersDTO.Bio,
                LanguageSpoke=providersDTO.LanguageSpoke,
                SocialLink1=providersDTO.SocialLink1,
                SocialLink2=providersDTO.SocialLink2,
                TimeOfService=providersDTO.TimeOfService,
                AreaServe=providersDTO.AreaServe,
                Availability=providersDTO.Availability,
                Skill1=providersDTO.Skill1,
                Skill2 =providersDTO.Skill2,
                Skill3=providersDTO.Skill3,
                ServiceName1=providersDTO.ServiceName1,
                ServicePrice1=providersDTO.ServicePrice1,
                ServiceImage1=providersDTO.ServiceImage1,
                ServiceName2=providersDTO.ServiceName2,
                ServicePrice2=providersDTO.ServicePrice2,
                ServiceImage2=providersDTO.ServiceImage2,
                ServiceName3=providersDTO.ServiceName3,
                ServicePrice3=providersDTO.ServicePrice3,
                ServiceImage3=providersDTO.ServiceImage3,
                area=providersDTO.area,
                State=providersDTO.State,
                District=providersDTO.District,
                PinCode=providersDTO.PinCode,
                City=providersDTO.City,
                Longitude=providersDTO.Longitude,
                Latitude=providersDTO.Latitude,
              
            };

            try
            {
                _dbContext.Providers.Add(data);
                _dbContext.SaveChanges();
            }
            catch (Exception e) {
                BadRequest(e.Message);
            
            }
            return Ok("Registration done successfully");
        }

    }
}
