using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceSeeker.Data;
using ServiceSeeker.Model;
using ServiceSeeker.Model.ProviderDTO;

using System.Net;
using System.Net.Mail;
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
        public ActionResult UserReg(PRegDTO providersDTO)
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
                ProfessionType = providersDTO.ProfessionType,
                YearOfEx = providersDTO.YearOfEx,
                Bio = providersDTO.Bio,
                LanguageSpoke = providersDTO.LanguageSpoke,
                SocialLink1 = providersDTO.SocialLink1,
                SocialLink2 = providersDTO.SocialLink2,
                TimeOfService = providersDTO.TimeOfService,
                AreaServe = providersDTO.AreaServe,
                Availability = providersDTO.Availability,
                Skill1 = providersDTO.Skill1,
                Skill2 = providersDTO.Skill2,
                Skill3 = providersDTO.Skill3,
                ServiceName1 = providersDTO.ServiceName1,
                ServicePrice1 = providersDTO.ServicePrice1,
                ServiceImage1 = providersDTO.ServiceImage1,
                ServiceName2 = providersDTO.ServiceName2,
                ServicePrice2 = providersDTO.ServicePrice2,
                ServiceImage2 = providersDTO.ServiceImage2,
                ServiceName3 = providersDTO.ServiceName3,
                ServicePrice3 = providersDTO.ServicePrice3,
                ServiceImage3 = providersDTO.ServiceImage3,
                area = providersDTO.area,
                State = providersDTO.State,
                District = providersDTO.District,
                PinCode = providersDTO.PinCode,
                City = providersDTO.City,
                Longitude = providersDTO.Longitude,
                Latitude = providersDTO.Latitude,

            };

            try
            {
                _dbContext.Providers.Add(data);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                BadRequest(e.Message);

            }
            return Ok("Registration done successfully");
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult UserLogin(PLoginDTO loginDto)
        {

            var userdata = _dbContext.Providers.FirstOrDefault(x => x.Email == loginDto.Email && x.Password == loginDto.Password);


            if (userdata == null)
            {

                return BadRequest("Invalid email or password");
            }
            var details = new providerDetailsDTO()
            {

                ProviderId = userdata.ProviderId,

                UserName = userdata.UserName,
                Email = userdata.Email,
                FirstName = userdata.FirstName,
                LastName = userdata.LastName,
                MiddleName = userdata.MiddleName,
                PhoneNumber = userdata.PhoneNumber,
                ProfilePhoto = userdata.ProfilePhoto,
                ProfessionType = userdata.ProfessionType,
                YearOfEx = userdata.YearOfEx,
                Bio = userdata.Bio,
                LanguageSpoke = userdata.LanguageSpoke,
                SocialLink1 = userdata.SocialLink1,
                SocialLink2 = userdata.SocialLink2,
                TimeOfService = userdata.TimeOfService,
                AreaServe = userdata.AreaServe,
                Availability = userdata.Availability,
                Skill1 = userdata.Skill1,
                Skill2 = userdata.Skill2,
                Skill3 = userdata.Skill3,
                ServiceName1 = userdata.ServiceName1,
                ServicePrice1 = userdata.ServicePrice1,
                ServiceImage1 = userdata.ServiceImage1,
                ServiceName2 = userdata.ServiceName2,
                ServicePrice2 = userdata.ServicePrice2,
                ServiceImage2 = userdata.ServiceImage2,
                ServiceName3 = userdata.ServiceName3,
                ServicePrice3 = userdata.ServicePrice3,
                ServiceImage3 = userdata.ServiceImage3,
                area = userdata.area,
                State = userdata.State,
                District = userdata.District,
                PinCode = userdata.PinCode,
                City = userdata.City,
                Longitude = userdata.Longitude,
                Latitude = userdata.Latitude,
            };





            return Ok(details);






        }

      
        [HttpPut]
        [Route("ChangePassword")]
        public ActionResult ChangePassword(int id, PChangePasswordDTO changePassword)
        {
            if (string.IsNullOrEmpty(changePassword.ExistingPassword) || string.IsNullOrEmpty(changePassword.NewPassword))
            {
                return BadRequest("Passwords cannot be empty.");
            }
            var user = _dbContext.Providers.FirstOrDefault(x => x.ProviderId == id && x.Password == changePassword.ExistingPassword);

            if (user != null)
            {
                user.Password = changePassword.NewPassword;
                _dbContext.SaveChanges();

                return Ok(new { Message = "Password changed successfully." });


            }

            return NotFound("Incorrect Password..!");

        }

        [HttpPost]
        [Route("ResetPassword")]
        public IActionResult ResetPassword([FromBody] PResetPasswordDTO resetDto)
        {
            var user = _dbContext.Providers.FirstOrDefault(x => x.Email == resetDto.Email);
            if (user == null)
            {
                return NotFound(new { Message = "User not found." });
            }

            // Validate OTP
            if (user.Otp != resetDto.Otp || user.OtpExpiry < DateTime.UtcNow)
            {
                return BadRequest(new { Message = "Invalid or expired OTP." });
            }

            // Update the password
            user.Password = resetDto.NewPassword; 
            user.Otp = null; // Clear the OTP after successful reset
            user.OtpExpiry = null;
            _dbContext.SaveChanges();

            return Ok(new { Message = "Password reset successfully." });
        }

        [HttpPost]
        [Route("GenerateOtp")]
        public IActionResult GenerateOtp([FromBody] string email)
        {
            var user = _dbContext.Providers.FirstOrDefault(x => x.Email == email);
            if (user == null)
            {
                return NotFound(new { Message = "User not found." });
            }

            // Generate a 6-digit OTP
            var otp = new Random().Next(100000, 999999).ToString();

            user.Otp = otp;
            user.OtpExpiry = DateTime.UtcNow.AddMinutes(10); // OTP valid for 10 minutes
            _dbContext.SaveChanges();

            SendOtpToUser(user.Email,user.FirstName, otp);

            return Ok(new { Message = "OTP sent successfully." });
        }

        private void SendOtpToUser(string email,string name, string otp)
        {
            try
            {
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
                    Subject = "Your OTP for Password Reset",
                    Body = $"Hello {name},\n\nYour OTP for resetting your password is: {otp}\n\nThis OTP is valid for 10 minutes.\n\nThank you,\nServiceSeeker Community",
                    IsBodyHtml = false,
                };
                mailMessage.To.Add(email);

                // Send the email
                smtpClient.Send(mailMessage);

                Console.WriteLine("OTP sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending OTP: {ex.Message}");
                // Log error and handle accordingly
            }




        }





    }
}
