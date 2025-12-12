using Microsoft.AspNetCore.Mvc;
using PatientsService.Models;
using PatientsService.Service;

namespace PatientsService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _service;
        public PatientsController(IPatientService service) => _service = service;

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var patient = _service.GetById(id);
            return patient == null ? NotFound() : Ok(patient);
        }

        [HttpPost]
        public IActionResult Add(Patient patient) => Ok(_service.Add(patient));

        [HttpPut("{id}")]
        public IActionResult Update(int id, Patient patient) => Ok(_service.Update(id, patient));

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => _service.Delete(id) ? NoContent() : NotFound();
    }
}
