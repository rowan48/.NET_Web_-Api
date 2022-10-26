using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Contracts;
using System.Security.Claims;

namespace Controllers.Controllers
{
    [Authorize]
    [Route("api/me")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;


        public UserController(IUserService service)
        {

            _service = service;
        }

        //  GET: api/me
        [HttpGet]

        public UserDTO UserInformation()
        {
            var id = User.FindFirstValue("UserId");
            int myid = Convert.ToInt32(id);
            return _service.GetById(myid);


        }





        // GET: api/Employees/5
        //[HttpGet("{id}")]
        //public UserDTO GetUser(int id)
        //{
        //    return _service.GetById(id);

        //}






        private bool UserExists(int id)
        {
            return false;
        }
    }
}
