using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentManagement.Models
{
    [Table("availability")]
    public class Availability
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("clinic_id")]
        public Guid ClinicId { get; set; }

        [Column("day_of_week")]
        public int DayOfWeek { get; set; }

        [Column("start_time", TypeName = "timestamp with time zone")]
        public DateTime StartTime { get; set; }

        [Column("end_time", TypeName = "timestamp with time zone")]
        public DateTime EndTime { get; set; }

        [Column("created_at", TypeName = "timestamp with time zone")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}