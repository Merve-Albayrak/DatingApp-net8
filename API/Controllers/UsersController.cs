
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace API.Controllers;

[Authorize]
public class   UsersController(DataContext context) : BaseApiController{
    private readonly DataContext _context = context;


[HttpGet]
    public async Task <ActionResult<IEnumerable<AppUser>>> GetUsers()
{

var users= await _context.Users.ToListAsync();

return users;


}
[Authorize]
[HttpGet("{id:int}")] //api/users/2

    public async Task< ActionResult<AppUser>> GetUser(int id)
{

var user= await _context.Users.FindAsync(id);

if(user==null) return NotFound();
return user;


}


}