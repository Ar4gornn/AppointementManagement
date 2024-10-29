using System;
using System.ComponentModel.DataAnnotations;

namespace AppointmentManagement.Models
{
    public class Appointment
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        [Required]
        [StringLength(255)]
        public string ProfessionalId { get; set; } = string.Empty;  // Initialize with empty string

        [Required]
        public Guid ClinicId { get; set; }

        [Required]
        [StringLength(255)]
        public string PatientId { get; set; }

        [Required]
        [StringLength(255)]
        public string PatientName { get; set; }

        [Phone]
        [StringLength(50)]
        public string PatientPhone { get; set; }

        [Required]
        public DateTime StartAt { get; set; }

        [Required]
        public DateTime EndAt { get; set; }

        [Required]
        [StringLength(100)]
        public string Type { get; set; }

        public int Status { get; set; } = 0;

        [StringLength(1000)]
        public string Notes { get; set; }

        public bool ShowedUp { get; set; } = false;

        [StringLength(255)]
        public string BookingChannel { get; set; }
    }
}
