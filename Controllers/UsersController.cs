using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
   
    public class UsersController(DataContext Context) : BaseApiController
    {
       
        [HttpGet]
        public async Task<ActionResult <IEnumerable<AppUser>>> GetUsers()
        {
            var users = await Context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{id:int}")]  // api/Users/1
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var user= await Context.Users.FindAsync(id);
            if(user==null) NotFound();
            return Ok(user);
        }
    }
}
