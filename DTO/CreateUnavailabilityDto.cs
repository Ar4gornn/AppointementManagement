namespace AppointmentManagement.DTO;

public class CreateUnavailabilityDto
{
    public Guid ClinicId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsAllDay { get; set; }
}