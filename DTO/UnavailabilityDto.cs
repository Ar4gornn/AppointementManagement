namespace AppointmentManagement.DTO;

public class UnavailabilityDto
{
    public Guid Id { get; set; }
    public Guid ClinicId { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public bool IsAllDay { get; set; }
}
