using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppointmentManagement.Models;

namespace AppointmentManagement.Repositories;
public interface IAppointmentRepository
{
    Task<IEnumerable<Appointment>> GetAppointmentsByClinicId(Guid clinicId, DateTime startDate, DateTime endDate);
    Task AddAppointment(Appointment appointment);
    Task<Appointment> GetAppointmentById(Guid appointmentId);
    Task UpdateAppointment(Appointment appointment);
    Task DeleteAppointment(Guid appointmentId);
    Task<IEnumerable<Appointment>> GetAppointmentByPatientID(string patientId);
}
