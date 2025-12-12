namespace PatientsService.Service
{
    using PatientsService.Data;

    using PatientsService.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class PatientService : IPatientService
    {
        private readonly PatientsDbContext _context;
        public PatientService(PatientsDbContext context) => _context = context;

        public List<Patient> GetAll() => _context.Patients.ToList();

        public Patient? GetById(int id) => _context.Patients.Find(id);

        public Patient Add(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
            return patient;
        }


        public Patient? Update(int id, Patient patient)
        {
            var existing = _context.Patients.Find(id);
            if (existing == null) return null;
            existing.Name = patient.Name;
            existing.BirthDate = patient.BirthDate;
            existing.Phone = patient.Phone;
            _context.SaveChanges();
            return existing;
        }

        public bool Delete(int id)
        {
            var patient = _context.Patients.Find(id);
            if (patient == null) return false;
            _context.Patients.Remove(patient);
            _context.SaveChanges();
            return true;
        }
    }

}
