namespace PatientsService.Service
{
    using PatientsService.Models;
    using System.Collections.Generic;

    public interface IPatientService
    {
        List<Patient> GetAll();
        Patient? GetById(int id);
        Patient Add(Patient patient);
        Patient? Update(int id, Patient patient);
        bool Delete(int id);
    }
}