using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentManagement.Models
{
    [Table("unavailabilities")]
    public class Unavailability
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("clinic_id")]
        public Guid ClinicId { get; set; }

        [Column("date", TypeName = "timestamp with time zone")]
        public DateTime Date { get; set; }

        [Column("start_time", TypeName = "timestamp with time zone")]
        public DateTime StartTime { get; set; }

        [Column("end_time", TypeName = "timestamp with time zone")]
        public DateTime EndTime { get; set; }

        [Column("is_allday")]
        public bool IsAllDay { get; set; }

        [Column("created_at", TypeName = "timestamp with time zone")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}