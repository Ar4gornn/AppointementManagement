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

        [Column("date")]
        public DateTime Date { get; set; } // DateTime for date

        [Column("start_time")]
        public TimeSpan StartTime { get; set; } // TimeSpan for time

        [Column("end_time")]
        public TimeSpan EndTime { get; set; } // TimeSpan for time

        [Column("is_allday")]
        public bool IsAllDay { get; set; }

        [Column("created_at", TypeName = "timestamp with time zone")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}