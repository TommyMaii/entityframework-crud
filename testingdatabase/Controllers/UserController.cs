using Microsoft.AspNetCore.Mvc;
using testingdatabase.Entities;

namespace testingdatabase.Controllers;

    [Route("api/[controller]")]
    [ApiController]

public class UserController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAllUsers()
    {
        var users = new List<User>
        {
            new User
            {
                userID = 1,
                userName = "admin",
                password = "admin",
            }
        };
        
        return Ok(users);
    }
}