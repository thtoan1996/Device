using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DeviceApp.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;

namespace DeviceApp.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceCategoriesController : ControllerBase
    {
        private readonly DeviceContext _context = new DeviceContext();
        //[EnableCors]
        [HttpGet]
        public IQueryable<DeviceCategories> GetDeviceCategories()
        {
            return _context.DeviceCategories;
        }

        // GET: api/DeviceCategories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeviceCategories([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deviceCategories = await _context.DeviceCategories.FindAsync(id);

            if (deviceCategories == null)
            {
                return NotFound();
            }

            return Ok(deviceCategories);
        }

        // PUT: api/DeviceCategories/5
        [HttpPut]
        public async Task<int> PutDeviceCategories(int id, string model)
        {
            Task<DeviceCategories> deviceCategories = _context.DeviceCategories.SingleOrDefaultAsync(x => x.DCId == id);

            if (deviceCategories.Result != null)
            {
                JsonConvert.PopulateObject(model, deviceCategories.Result);
                await _context.SaveChangesAsync();
            }
            return 0;
        }
        // POST: api/DeviceCategories
        [HttpPost]
        public async Task<int> PostDeviceCategories(String model)
        {
            if (model != null)
            {
                var item = new DeviceCategories();

                JsonConvert.PopulateObject(model, item);
                _context.DeviceCategories.Add(item);
                await _context.SaveChangesAsync();
                return item.DCId;
            }
            return 0;

        }

        // DELETE: api/DeviceCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeviceCategories([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deviceCategories = await _context.DeviceCategories.FindAsync(id);
            if (deviceCategories == null)
            {
                return NotFound();
            }

            _context.DeviceCategories.Remove(deviceCategories);
            await _context.SaveChangesAsync();

            return Ok(deviceCategories);
        }

        private bool DeviceCategoriesExists(int id)
        {
            return _context.DeviceCategories.Any(e => e.DCId == id);
        }
    }
}