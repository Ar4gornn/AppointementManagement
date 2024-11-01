using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentManagement.Models
{
    [Table("clinics")]
    public class Clinic
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        [StringLength(255)]
        public string? Name { get; set; }

        [Column("title")]
        [StringLength(100)]
        public string? Title { get; set; }

        [Column("picture_url")]
        public string? PictureUrl { get; set; }

        [Column("specialty")]
        [StringLength(100)]
        public string? Specialty { get; set; }

        [Column("address")]
        public string? Address { get; set; }

        [Column("detailed_address")]
        public string? DetailedAddress { get; set; }

        [Column("map_url")]
        public string? MapUrl { get; set; }

        [Column("allow_new_patient_book")]
        public bool? AllowNewPatientBooking { get; set; }

        [Column("allow_patient_booking")]
        public bool AllowPatientBooking { get; set; }

        [Column("created_at", TypeName = "timestamp with time zone")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at", TypeName = "timestamp with time zone")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}