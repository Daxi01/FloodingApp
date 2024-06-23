using Microsoft.AspNetCore.Mvc;
using FloodingApp.Models;
using Newtonsoft.Json;
using System;

namespace FloodingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly FloodMonitoringContext _context;

        public ValuesController(FloodMonitoringContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostValue([FromBody] Value value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Console.WriteLine("Invalid model state:");
                    Console.WriteLine(JsonConvert.SerializeObject(ModelState));
                    return BadRequest(ModelState);
                }

                Console.WriteLine("Received value:");
                Console.WriteLine(JsonConvert.SerializeObject(value));

                _context.Values.Add(value);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetValue", new { id = value.Id }, value);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                Console.WriteLine(ex.StackTrace);

                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetValue(Guid id)
        {
            var value = _context.Values.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }
    }
}
