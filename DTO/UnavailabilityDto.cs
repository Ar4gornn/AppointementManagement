namespace AppointmentManagement.DTO;

public class UnavailabilityDto
{
    public Guid Id { get; set; }
    public Guid ClinicId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsAllDay { get; set; }
}