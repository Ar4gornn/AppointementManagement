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
        public DateTime Date { get; set; }

        [Column("start_time")]
        public TimeSpan StartTime { get; set; }  

        [Column("end_time")]
        public TimeSpan EndTime { get; set; } 

        [Column("is_allday")]
        public bool IsAllDay { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  
    }
}