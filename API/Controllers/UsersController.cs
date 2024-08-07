using Microsoft.AspNetCore.Mvc;
using API.Entities;
using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController:ControllerBase{
        private readonly DataContext _context;
        public UsersController(DataContext context){
            _context=context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>>GetUsers(){
            var users= await _context.Users.ToListAsync<AppUser>();
            return users ; //return Ok(users)
        }

        [HttpGet("{id:int}")]     //api/users/2
        public async Task<ActionResult<AppUser>> GetUser(int id){
           // var user=_context.Users.FirstOrDefault(x=>x.Id==id);
            var user=await _context.Users.FindAsync(id);
            if(user==null) return NotFound();

            return user;//return Ok(user)
        }
    }
    
}