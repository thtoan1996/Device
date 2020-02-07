using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DeviceApp.Models;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace DeviceApp.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DeviceContext _context = new DeviceContext();
        //[EnableCors]
        [HttpGet]
        public IQueryable<Users> GetUsers()
        {
            return _context.Users;
        }

        // GET: api/Users/5
        //[EnableCors]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users = await _context.Users.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // PUT: api/Users/5        
        [HttpPut]
        public async Task<int> PutUsers(int id, String model)
        {
            Task<Users> users = _context.Users.SingleOrDefaultAsync(x => x.UId == id);

            if(users.Result != null)
            {
                JsonConvert.PopulateObject(model, users.Result);
                await _context.SaveChangesAsync();
            }
            return 0;
        }

        // POST: api/Users
        [HttpPost]
        public async Task<int> PostUsers(String model)
        {
            if (model != null)
            {
                var item = new Users();

                JsonConvert.PopulateObject(model, item);
                _context.Users.Add(item);
                await _context.SaveChangesAsync();
                return item.UId;
            }
            return 0;

        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers([FromRoute] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.Users.Remove(users);
            await _context.SaveChangesAsync();

            return Ok(users);
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.UId == id);
        }
    }
}