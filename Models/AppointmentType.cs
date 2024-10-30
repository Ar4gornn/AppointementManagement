
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentManagement.Models
{
    [Table("appointment_types")]
    public class AppointmentType
    
    {
        [Column("id")]
        public Guid Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("clinic_id")]
        public Guid ClinicId { get; set; }
    }
}