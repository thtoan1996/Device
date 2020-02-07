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

namespace DeviceApp.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly DeviceContext _context = new DeviceContext();

        // GET: api/Devices
        [HttpGet]
        public IEnumerable<Devices> GetDevices()
        {
            return _context.Devices;
        }

        // GET: api/Devices/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDevices([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var devices = await _context.Devices.FindAsync(id);

            if (devices == null)
            {
                return NotFound();
            }

            return Ok(devices);
        }

        // PUT: api/Devices/5
        [HttpPut]
        public async Task<int> PutDevices(int id, String model)
        {
            Task<Devices> devices = _context.Devices.SingleOrDefaultAsync(x => x.DId == id);

            if (devices.Result != null)
            {
                JsonConvert.PopulateObject(model, devices.Result);
                await _context.SaveChangesAsync();
            }
            return 0;
        }
        //public async Task<IActionResult> PutDevices([FromRoute] int id, [FromBody] Devices devices)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != devices.DId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(devices).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DevicesExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Devices
        [HttpPost]
        public async Task<int> PostDevices(String model)
        {
            if (model != null)
            {
                var item = new Devices();

                JsonConvert.PopulateObject(model, item);
                _context.Devices.Add(item);
                await _context.SaveChangesAsync();
                return item.DId;
            }
            return 0;

        }
        //public async Task<IActionResult> PostDevices([FromBody] Devices devices)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.Devices.Add(devices);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetDevices", new { id = devices.DId }, devices);
        //}

        // DELETE: api/Devices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevices([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var devices = await _context.Devices.FindAsync(id);
            if (devices == null)
            {
                return NotFound();
            }

            _context.Devices.Remove(devices);
            await _context.SaveChangesAsync();

            return Ok(devices);
        }

        private bool DevicesExists(int id)
        {
            return _context.Devices.Any(e => e.DId == id);
        }
    }
}