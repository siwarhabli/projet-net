using AppointmentsService.Data;
using AppointmentsService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppointmentsService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly AppointmentsDbContext _context;

        public AppointmentsController(AppointmentsDbContext context)
        {
            _context = context;
        }

        // GET api/appointments
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _context.Appointments.ToListAsync();
            return Ok(list);
        }

        // GET api/appointments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
                return NotFound("Appointment not found");

            return Ok(appointment);
        }

        // POST api/appointments
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Appointment appointment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            return Ok("Appointment created");
        }

        // PUT api/appointments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Appointment appointment)
        {
            var existing = await _context.Appointments.FindAsync(id);
            if (existing == null)
                return NotFound("Appointment not found");

            existing.PatientId = appointment.PatientId;
            existing.DoctorId = appointment.DoctorId;
            existing.AppointmentDate = appointment.AppointmentDate;

            await _context.SaveChangesAsync();

            return Ok("Appointment updated");
        }

        // DELETE api/appointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
                return NotFound("Appointment not found");

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();

            return Ok("Appointment deleted");
        }
    }
}
