using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentManagement.Models
{
    [Table("appointment_types")]
    public class AppointmentType
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("clinic_id")]
        public Guid ClinicId { get; set; }

        [Column("name")]
        [StringLength(100)]
        public string? Name { get; set; }

        [Column("created_at", TypeName = "timestamp with time zone")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}