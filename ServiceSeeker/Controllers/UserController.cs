
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceSeeker.Data;
using ServiceSeeker.Model;
using ServiceSeeker.Model.UserDTO;
using System.Net.Mail;
using System.Net;


namespace ServiceSeeker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ServiceSeekerDB _dbContext;

        public UserController(ServiceSeekerDB _dbContext)
        {
            this._dbContext = _dbContext;
        }
        [HttpGet]
        public ActionResult GetUser()

        {
            var allUser = _dbContext.Users.ToList();
            return Ok(allUser);
        }

        [HttpPost]
        [Route("Registration")]
        public ActionResult UserReg(regDTO usersDTO)
        {
            if (usersDTO == null)
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
            var existingUser = _dbContext.Users.FirstOrDefault(x => x.Email == usersDTO.Email || x.UserName == usersDTO.UserName);
            if (existingUser != null)
            {

                return BadRequest("User already exists with same email address");

            }

            var data = new User()
            {
                UserId = usersDTO.UserId,
                CreatAt = DateTime.Now,
                UserName = usersDTO.UserName,
                Email = usersDTO.Email,
                FirstName = usersDTO.FirstName,
                LastName = usersDTO.LastName,
                MiddleName = usersDTO.MiddleName,
                Password = usersDTO.Password,
                PhoneNumber = usersDTO.PhoneNumber
            };


            _dbContext.Users.Add(data);
            _dbContext.SaveChanges();


            return Ok("Registration done successfully");
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult UserLogin(loginDTO loginDto)
        {

            var userdata = _dbContext.Users.FirstOrDefault(x => x.Email == loginDto.Email && x.Password == loginDto.Password);


            if (userdata == null)
            {

                return BadRequest("Invalid email or password");
            }
            var details = new userDetailsDTO()
            {
                UserName = userdata.UserName,

                FirstName = userdata.FirstName,
                MiddleName = userdata.MiddleName,
                LastName = userdata.LastName,
                Email = userdata.Email,
                PhoneNumber = userdata.PhoneNumber
            };





            return Ok(details);






        }

        [HttpPut]
        [Route("Update")]
        public ActionResult UserUpdate(int id, updateDetailsDTO userdto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = _dbContext.Users.FirstOrDefault(x => x.UserId == id);
            if (user == null)
            {
                return NotFound("User id is invalid..");

            }
            // Update only the provided properties
            if (!string.IsNullOrEmpty(userdto.UserName) && user.UserName != userdto.UserName)
            {
                var existingUser = _dbContext.Users.FirstOrDefault(x => x.UserName == userdto.UserName);
                if (existingUser != null)
                {

                    return BadRequest("username not available..");

                }
                user.UserName = userdto.UserName;
            }

            if (!string.IsNullOrEmpty(userdto.FirstName))
            {
                user.FirstName = userdto.FirstName;
            }

            if (!string.IsNullOrEmpty(userdto.LastName))
            {
                user.LastName = userdto.LastName;
            }

            if (!string.IsNullOrEmpty(userdto.MiddleName))
            {
                user.MiddleName = userdto.MiddleName;
            }

            if (userdto.PhoneNumber.Equals(""))
            {
                user.PhoneNumber = userdto.PhoneNumber;
            }

            if (!string.IsNullOrEmpty(userdto.Email) && user.Email != userdto.Email)
            {
                var existingUser = _dbContext.Users.FirstOrDefault(x => x.Email == userdto.Email);
                if (existingUser != null)
                {

                    return BadRequest("email already registered..");

                }

                user.Email = userdto.Email;
            }

            // Save the changes to the database
            _dbContext.SaveChanges();

            return Ok(new { Message = "User updated successfully." });
        }

        [HttpPut]
        [Route("changePassword")]
        public ActionResult ChangePassword(int id ,changePasswordDTO changePassword)
        {
            if (string.IsNullOrEmpty(changePassword.existingPassword) || string.IsNullOrEmpty(changePassword.newPassword))
            {
                return BadRequest("Passwords cannot be empty.");
            }
            var user = _dbContext.Users.FirstOrDefault(x => x.UserId == id && x.Password== changePassword.existingPassword);
            
            if (user != null)
            {
                user.Password = changePassword.newPassword;
                _dbContext.SaveChanges();

                return Ok(new { Message = "Password chnaged successfully." });


            }
            
           
                return NotFound("Incorrect Password..!");


            
           
        }

        [HttpPost]
        [Route("ResetPassword")]
        public IActionResult ResetPassword([FromBody] resetPasswordDTO resetDto)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Email == resetDto.Email);
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
            user.Password = resetDto.NewPassword; // Hash the password for better security
            user.Otp = null; // Clear the OTP after successful reset
            user.OtpExpiry = null;
            _dbContext.SaveChanges();

            return Ok(new { Message = "Password reset successfully." });
        }

        [HttpPost]
        [Route("GenerateOtp")]
        public IActionResult GenerateOtp([FromBody] string email)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Email == email);
            if (user == null)
            {
                return NotFound(new { Message = "User not found." });
            }

            // Generate a 6-digit OTP
            var otp = new Random().Next(100000, 999999).ToString();

            // Save OTP and expiry time to the user record
            user.Otp = otp;
            user.OtpExpiry = DateTime.UtcNow.AddMinutes(10); // OTP valid for 10 minutes
            _dbContext.SaveChanges();

            // Simulate sending OTP (replace with actual email/SMS service)
            SendOtpToUser(user.Email, otp);

            return Ok(new { Message = "OTP sent successfully." });
        }

        private void SendOtpToUser(string email, string otp)
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
                    Body = $"Hello,\n\nYour OTP for resetting your password is: {otp}\n\nThis OTP is valid for 10 minutes.\n\nThank you,\nServiceSeeker Team",
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

