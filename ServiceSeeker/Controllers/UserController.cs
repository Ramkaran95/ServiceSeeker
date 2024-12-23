using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ServiceSeeker.Data;
using ServiceSeeker.Model;
using System.Numerics;

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
            var allUser =_dbContext.Users.ToList();
            return Ok(allUser);
        }
        [HttpPost]
        public ActionResult AddUser(UsersDTO usersDTO)
        {
            var existingUser = _dbContext.Users.FirstOrDefault(u => u.UserId == usersDTO.ID);

            if (existingUser != null)
            {
                return BadRequest("User already exists");
            }

            var data = new User
            {
                UserId = usersDTO.ID,
                UserName = usersDTO.UserName,
                Email = usersDTO.Email,
                FirstName = usersDTO.FirstName,
                LastName = usersDTO.LastName,
                MiddleName = usersDTO.MiddleName,
                Password = usersDTO.Password,
                PhoneNumber = usersDTO.PhoneNumber,
                //ProfilePhoto = usersDTO.ProfilePhoto,
                CreatAt = usersDTO.CreatAt
            };

            try
            {
                _dbContext.Users.Add(data);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Added Successfully");
        }
    }
}
