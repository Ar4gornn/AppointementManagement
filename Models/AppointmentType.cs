
namespace AppointmentManagement.Models
{
    public class AppointmentType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ClinicId { get; set; }
    }
}