namespace AppointmentManagement.DTO;

public class CreateUnavailabilityDto
{
    public Guid ClinicId { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public bool IsAllDay { get; set; }
}