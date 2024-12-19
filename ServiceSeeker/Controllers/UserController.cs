using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ServiceSeeker.Data;
using ServiceSeeker.Model;

namespace ServiceSeeker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ServiceSeekerDB dbContext;

        public UserController(ServiceSeekerDB dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public ActionResult GetUser()
        
        {
            var allUser =dbContext.Users.ToList();
            return Ok(allUser);
        }
        [HttpPost]

        public ActionResult AddUser(UsersDTO usersDTO) 
        {
            var data = new User() {
                UserId = usersDTO.ID,
                UserName = usersDTO.UserName,
                Email = usersDTO.Email,
                FirstName = usersDTO.FirstName,
                LastName = usersDTO.LastName,
                MiddleName = usersDTO.MiddleName,
                Password = usersDTO.Password,
                PhoneNumber = usersDTO.PhoneNumber,
                ProfilePhoto = usersDTO.ProfilePhoto,
                CreatAt = usersDTO.CreatAt
            };


            dbContext.Users.Add(data);
            dbContext.SaveChanges();
            

         return Ok("Add Succesfully");
        }

    }
}
