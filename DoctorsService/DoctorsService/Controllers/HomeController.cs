using DoctorsService.Data;
using DoctorsService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoctorsService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly PatientsDbContext _context;

        public HomeController(PatientsDbContext context)
        {
            _context = context;
        }

        // GET api/home
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var doctors = await _context.Doctors.ToListAsync();
            return Ok(doctors);
        }

        // GET api/home/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
                return NotFound("Doctor not found");

            return Ok(doctor);
        }

        // POST api/home
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Doctor doctor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

            return Ok("Doctor created");
        }

        // PUT api/home/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Doctor doctor)
        {
            var existing = await _context.Doctors.FindAsync(id);
            if (existing == null)
                return NotFound("Doctor not found");

            existing.Name = doctor.Name;
            existing.Speciality = doctor.Speciality;

            await _context.SaveChangesAsync();
            return Ok("Doctor updated");
        }

        // DELETE api/home/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
                return NotFound("Doctor not found");

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();

            return Ok("Doctor deleted");
        }
    }
}
