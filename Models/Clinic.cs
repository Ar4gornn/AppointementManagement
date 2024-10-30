
namespace AppointmentManagement.Models
{
    public class Clinic
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? PictureUrl { get; set; }
        public string? Specialty { get; set; }
        public string? Address { get; set; }
        public string? DetailedAddress { get; set; }
        public string? MapUrl { get; set; }
        public bool AllowNewPatientBooking { get; set; }
        public bool AllowPatientBooking { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}