using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceSeeker.Data;
using static System.Net.WebRequestMethods;
using System.Net.Mail;
using System.Net;
using ServiceSeeker.Model.FeaturesDTO;
using ServiceSeeker.Model.ProviderDTO;

namespace ServiceSeeker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly ServiceSeekerDB _dbContext;
        public FeaturesController(ServiceSeekerDB _dbContext)
        {
            this._dbContext = _dbContext;
        }


        [HttpPost]
        [Route("Contact")]
        public IActionResult Contact(ContactDTO  contactDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var check = _dbContext.Users.FirstOrDefault(x => x.Email == contactDTO.Email);
            var check1 = _dbContext.Providers.FirstOrDefault(x => x.Email == contactDTO.Email);
            if (check == null && check1 == null) {
                return NotFound(new { Message = "Password chnaged successfully." });
            }

            try

            {
                var email = "serviceseekerhelp@gmail.com";
                // Configure SMTP settings
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587, // Default port for SMTP
                    Credentials = new NetworkCredential("death95035@gmail.com", "onoj nxjb riqw fjql"),
                    EnableSsl = true,
                };

                // Compose the email
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("death95035@gmail.com", "ServiceSeeker Support"),
                    Subject = "Response From Client",
                    Body = $"From {contactDTO.Fullname},\n\nMessage: {contactDTO.Msg} \n\n Email of Client {contactDTO.Email}",
                    IsBodyHtml = false,
                };
                mailMessage.To.Add(email);

                // Send the email
                smtpClient.Send(mailMessage);

                Console.WriteLine("Message sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending OTP: {ex.Message}");
                // Log error and handle accordingly
            }


            return Ok(new { Message = "Message sent successfully." });
        }

        [HttpGet]
        [Route("ProviderByLocation")]
        public ActionResult ProviderByLocation( string city, int pinCode,string district ,string profession)
        {
            try
            {
                var providers = _dbContext.Providers
                    .Where(p => (p.PinCode == pinCode && p.ProfessionType == profession) || 
                (p.District == district && p.ProfessionType == profession))
                    .OrderBy(p => p.City == city ? 0 : 1 )
                    .ThenBy(p => p.City )
                    .ThenBy(p => p.District == district ? 0 : 1)



                    .Select(p => new ProviderByLocationDTO
                    {
                        ProviderId = p.ProviderId,
                        UserName = p.UserName,
                        FirstName = p.FirstName,
                        MiddleName = p.MiddleName,
                        LastName = p.LastName,
                        ProfilePhoto = p.ProfilePhoto,
                        PhoneNumber = p.PhoneNumber,
                        Email = p.Email,
                        CreateAt = p.CreateAt,
                        ProfessionType = p.ProfessionType,
                        YearOfEx = p.YearOfEx,
                        Bio = p.Bio,
                        LanguageSpoke = p.LanguageSpoke,
                        SocialLink1 = p.SocialLink1,
                        SocialLink2 = p.SocialLink2,
                        TimeOfService = p.TimeOfService,
                        AreaServe = p.AreaServe,
                        Availability = p.Availability,
                        Skill1 = p.Skill1,
                        Skill2 = p.Skill2,
                        Skill3 = p.Skill3,
                        ServiceName1 = p.ServiceName1,
                        ServicePrice1 = p.ServicePrice1,
                        ServiceImage1 = p.ServiceImage1,
                        ServiceName2 = p.ServiceName2,
                        ServicePrice2 = p.ServicePrice2,
                        ServiceImage2 = p.ServiceImage2,
                        ServiceName3 = p.ServiceName3,
                        ServicePrice3 = p.ServicePrice3,
                        ServiceImage3 = p.ServiceImage3,
                        Area =p.area,
                        State = p.State,
                        District = p.District,
                        PinCode = p.PinCode,
                        City = p.City,
                        Longitude = p.Longitude,
                        Latitude = p.Latitude
                    })
                    .ToList();

                return Ok(providers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while fetching the data.", Error = ex.Message });
            }
        }


    }
}
