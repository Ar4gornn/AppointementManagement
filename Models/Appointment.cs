using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentManagement.Models
{
    [Table("appointments")]
    public class Appointment
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("patient_name")]
        [Required]
        [StringLength(255)]
        public string PatientName { get; set; }

        [Column("patient_number")]
        [StringLength(20)]
        public string PatientPhone { get; set; }

        [Column("patient_id")]
        public Guid PatientId { get; set; }

        [Column("clinic_id")]
        public Guid ClinicId { get; set; }

        [Column("type")]
        [StringLength(100)]
        public string Type { get; set; }

        [Column("start_at", TypeName = "timestamp with time zone")]
        public DateTime StartAt { get; set; }

        [Column("end_at", TypeName = "timestamp with time zone")]
        public DateTime EndAt { get; set; }

        [Column("notes")]
        public string Notes { get; set; }

        [Column("status")]
        public int Status { get; set; }

        [Column("booking_channel")]
        [StringLength(100)]
        public string BookingChannel { get; set; }

        [Column("created_at", TypeName = "timestamp with time zone")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at", TypeName = "timestamp with time zone")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}