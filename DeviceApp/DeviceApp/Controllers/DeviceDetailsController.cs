using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DeviceApp.Models;
using Newtonsoft.Json;

namespace DeviceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceDetailsController : ControllerBase
    {
        private readonly DeviceContext _context = new DeviceContext();

        // GET: api/DeviceDetails
        [HttpGet]
        public IEnumerable<DeviceDetails> GetDeviceDetails()
        {
            return _context.DeviceDetails;
        }

        // GET: api/DeviceDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeviceDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deviceDetails = await _context.DeviceDetails.FindAsync(id);

            if (deviceDetails == null)
            {
                return NotFound();
            }

            return Ok(deviceDetails);
        }

        // PUT: api/DeviceDetails/5
        [HttpPut]
        public async Task<int> PutDeviceDetails(int id, String model)
        {
            Task<DeviceDetails> deviceDetails = _context.DeviceDetails.SingleOrDefaultAsync(x => x.DId == id);
            //Task<DeviceDetails> deviceDetail = _context.DeviceDetails.SingleOrDefaultAsync(x => x.UId == id);
            if (deviceDetails.Result != null)
            {
                JsonConvert.PopulateObject(model, deviceDetails.Result);
                await _context.SaveChangesAsync();
            }
            return 0;
        }
        //public async Task<IActionResult> PutDeviceDetails([FromRoute] int id, [FromBody] DeviceDetails deviceDetails)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != deviceDetails.UId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(deviceDetails).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DeviceDetailsExists(id))
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

        // POST: api/DeviceDetails
        [HttpPost]
        public async Task<int> PostDeviceDetails(String model)
        {
            if (model != null)
            {
                var item = new DeviceDetails();

                JsonConvert.PopulateObject(model, item);
                _context.DeviceDetails.Add(item);
                await _context.SaveChangesAsync();
                return item.DId;
            }
            return 0;

        }
        //public async Task<IActionResult> PostDeviceDetails([FromBody] DeviceDetails deviceDetails)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.DeviceDetails.Add(deviceDetails);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (DeviceDetailsExists(deviceDetails.UId))
        //        {
        //            return new StatusCodeResult(StatusCodes.Status409Conflict);
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetDeviceDetails", new { id = deviceDetails.UId }, deviceDetails);
        //}

        // DELETE: api/DeviceDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeviceDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deviceDetails = await _context.DeviceDetails.FindAsync(id);
            if (deviceDetails == null)
            {
                return NotFound();
            }

            _context.DeviceDetails.Remove(deviceDetails);
            await _context.SaveChangesAsync();

            return Ok(deviceDetails);
        }

        private bool DeviceDetailsExists(int id)
        {
            return _context.DeviceDetails.Any(e => e.UId == id);
        }
    }
}