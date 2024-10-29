using System;

namespace AppointmentManagement.Models
{
    public class Clinic
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Specialty { get; set; }
        public bool AllowNewPatientBooking { get; set; }
    }
}