using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentManagement.Models
{
    [Table("appointments")]
    public class Appointment
    {
        [Column("id")]
        public Guid Id { get; set; } = Guid.NewGuid();
        
        [Column("patient_id")]
        [Required]
        public Guid PatientId { get; set; }  

        [Column("patient_name")]
        [Required]
        [StringLength(255)]
        public string PatientName { get; set; }

        [Column("patient_number")]
        [Phone]
        [StringLength(20)]
        public string PatientPhone { get; set; }

        [Column("clinic_id")]
        [Required]
        public Guid ClinicId { get; set; }

        [Column("start_at")]
        [Required]
        public DateTime StartAt { get; set; }

        [Column("end_at")]
        [Required]
        public DateTime EndAt { get; set; }

        [Column("type")]
        [Required]
        [StringLength(100)]
        public string Type { get; set; }

        [Column("status")]
        public int Status { get; set; } = 0;

        [Column("notes")]
        [StringLength(1000)]
        public string Notes { get; set; }

        [Column("showed_up")]
        public bool ShowedUp { get; set; } = false;

        [Column("booking_channel")]
        [StringLength(100)]
        public string BookingChannel { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}