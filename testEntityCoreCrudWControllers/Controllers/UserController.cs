using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testEntityCoreCrudWControllers.Data;
using testEntityCoreCrudWControllers.Entities;

namespace testingdatabase.Controllers;

[Route("api/[controller]")]
[ApiController]

public class UserController : ControllerBase
{
    private readonly DataContext _context;

    public UserController(DataContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAllUsers()
    {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
    }    
    
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
            var user = await _context.Users.FindAsync(id);
            if(user is null)
                return NotFound("User not found");
            return Ok(user);
    }    
    
    [HttpPost]
    public async Task<ActionResult<List<User>>> AddUser(User user)
    {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Users.ToListAsync());
    }  
    
    [HttpPut]
    public async Task<ActionResult<List<User>>> UpdateUser(User updatedUser)
    {
            var dbUser = await _context.Users.FindAsync(updatedUser.userID);
            
            if(dbUser is null)
                return NotFound("User not found");
            
            dbUser.userName = updatedUser.userName;
            dbUser.password = updatedUser.password;
            
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Users.ToListAsync());
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<User>>> DeleteUser(int id)
    {
        var dbUser = await _context.Users.FindAsync(id);
            if(dbUser is null)
                return NotFound("User not found");
            
        _context.Users.Remove(dbUser);
            
        await _context.SaveChangesAsync();
            
        return Ok(await _context.Users.ToListAsync());
    }
}