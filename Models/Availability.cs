using System;

namespace AppointmentManagement.Models
{
    public class Availability
    {
        public Guid Id { get; set; }
        public Guid ClinicId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}